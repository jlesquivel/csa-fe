
Imports System.ComponentModel
Imports DevComponents.DotNetBar
Imports System.IO
Imports System.Net.Http
Imports System.Threading
Imports System.IdentityModel.Tokens.Jwt
Imports Newtonsoft.Json
Imports EG.EnviaFactura

Public Class Form1

   Public Property xmlRespuesta As Xml.XmlDocument
   Public Property jsonEnvio As String = ""
   Public Property jsonRespuesta As String = ""
   Public Property mensajeRespuesta As String = ""
   Public Property estadoFactura As String = ""
   Public Property statusCode As String = ""

   Delegate Sub MensajeCallBack(ByVal msg As String)
   Delegate Sub MensajeCallBackHeaders(ByVal msg As HttpResponseMessage)

   Dim _event As ManualResetEvent = New ManualResetEvent(True)
   Dim hiloFactura As Thread = New Thread(AddressOf GenerarFactura)

   Dim conn As ConexionSQL

   Dim CSA_config As confComunicacion
   Dim emisor As Integer = 1
   Dim emisorModo As String = ""

   Public Property cnf As DataRow


   '*******************************************************************
#Region "Activa Hilo Procesa Facturas"

   Sub GenerarFactura()

      Dim idFact As Integer
      Dim TK As String = ""
      Dim TKexpired As Boolean = True
      Dim iTokenHacienda As New TokenHacienda

      Dim factParalelas As Integer = cnf.Item("factParalelas")

      While True

            Try
                If Not HaySistemas() Then

                    ActLog("ERROR *** sin sistema")
                    Thread.Sleep(60000)
                Else

                    'If CInt(lbDisponible.Text) >= (factParalelas * 2) Then
                    factParalelas = cnf.Item("factParalelas")

                    Dim sql As String = $"select top {factParalelas} id from [fact.factura] where enc_clave is null"
                    Dim factDB = conn.llenaTabla(sql)

                    Dim facturar As New cFactura With {.rutaArchivos = cnf.Item("rutaArch")}

                    '?//// token
                    If TK = "" Or TokenExpirado(TK) Then
                        ActLog("Solicitando Token *****")
                        iTokenHacienda.GetTokenHacienda(CSA_config.apiUsuario, CSA_config.apiClave)

                        TK = iTokenHacienda.accessToken
                        ActLog($"Token expira en : {tokenExpiraEn(TK)}")
                    End If

                    '! recorrer tabla y generar cada archivo
                    If factDB.Rows.Count > 0 Then

                        Dim consultas As Integer = factDB.Rows.Count

                        Dim doneEvents(consultas - 1) As ManualResetEvent
                        Dim hilosArray(consultas - 1) As GestionaFactura

                        ActLog($"Grupo de {factDB.Rows.Count} facturas...")

                        Dim i As Integer = 0
                        For Each fila In factDB.Rows
                            idFact = fila.item("id")
                            ActLog($"factura: {idFact}")

                            doneEvents(i) = New ManualResetEvent(False)
                            Dim f As GestionaFactura
                            f = New GestionaFactura(CSA_config, idFact, cnf, TK, doneEvents(i))
                            hilosArray(i) = f
                            ThreadPool.QueueUserWorkItem(AddressOf f.GeneraFactura, i)
                            i += 1
                        Next

                        Dim esperar As Thread = New Thread(AddressOf EsperarTermine)
                        esperar.Start(doneEvents)
                        '? Ahora espere por este nuevo hilo.
                        esperar.Join()

                        '? Muestra los resultados
                        For i = 0 To consultas - 1
                            Dim f As GestionaFactura = hilosArray(i)
                            ActLog($"# {f.idFact} = {f.resultado} " &
                                  IIf(f.MensajeError.Length > 0, $", error: {f.MensajeError}", ""))

                            ActLabel(f.response)
                        Next
                        ActLog(". . . . . . . ")

                    Else


                        revisa_estado_comprobante(factParalelas, TK)

                    End If

                End If

            Catch ex As Exception
                ActLog("ERROR ***:" & ex.Message & " ::: " & ex.StackTrace)
            'Throw New Exception(ex.Message)
            Thread.Sleep(5000)
         End Try
      End While

   End Sub

    Private Sub revisa_estado_comprobante(factParalelas As Integer, TK As String)

        '?  SINO HAY FACTURA  VERIFICAR LAS FACTURAS ENVIADAS
        '?     =>   VERIFICAR LAS FACTURAS ENVIADAS

        Dim Sql = $"select top {factParalelas} id,enc_clave from [fact.factura] where confirmacionMsg is null or confirmacionMsg ='' "
        Dim factDB = conn.llenaTabla(Sql)

        Dim sqlActualiza As String = ""

        Dim clave As String = ""
        Dim envia = New enviaHacienda(CSA_config)
        Dim idFact

        For Each fila In factDB.Rows
            idFact = fila.item("id")
            clave = fila.item("enc_clave")
            ActLog($"Factura: {idFact}")

            Dim compro As New EG.EnviaFactura.Comprobante
            compro = envia.comprobante(clave, TK)  ''ok
            Dim respuesta As String = envia.jsonRespuesta

            Select Case envia.estado
                Case "200"
                    sqlActualiza = $"UPDATE [fact.factura] SET confirmacionMsg = '{respuesta}' WHERE (Id = {idFact})"
                    conn.ejecuta(sqlActualiza)

                    ActLog($"Confirmación: {respuesta}")
                Case "404"
                    '?     =>   SINO FUE RECIBIDA ;;; REENVIA DE NUEVO Y LIMIPA confirmacionMSG en tabla fac.factura
                    '? ojo actualizar el nombre del archivo XML
                    Dim rutaArchivos = cnf.Item("rutaArch") & "\" & clave & ".xml"
                    If File.Exists(rutaArchivos) Then
                        ReenviaXML_Hda(idFact, rutaArchivos, CSA_config, TK)
                    End If

                Case Else
                    ActLog($"error: {envia.respuestaHacienda}")
            End Select
        Next
    End Sub



    Private Sub ReenviaXML_Hda(idFact As Integer, archivoXML As String, emisor As confComunicacion, TK As String)
      Try
         Dim envia As Object
         Dim response As HttpResponseMessage
         Dim respuesta As String = ""

         envia = New enviaHacienda(archivoXML, emisor, TK)
         respuesta = envia.Procesa()
         response = envia.response

         Dim instSQL = $"UPDATE [fact.factura] SET confirmacion = '',confirmacionMsg = N'' where id = {idFact} "
         conn.ejecuta(instSQL)

      Catch ex As Exception
         Throw
      End Try
   End Sub


   Private Sub EsperarTermine(eventos As Object)
      Dim evs() As ManualResetEvent = eventos
      WaitHandle.WaitAll(evs)   '' espera que terminen todo los hilos
   End Sub


   Function TokenExpirado(pTK As String) As Boolean
      If pTK <> "" Then
         Dim handler As JwtSecurityTokenHandler = New JwtSecurityTokenHandler()
         Dim tokenS = handler.ReadToken(pTK)
         Return (fechaCR(tokenS.ValidTo) <= Now.AddMinutes(1))
      Else
         Return True
      End If
   End Function

   Function tokenExpiraEn(pTK) As String
      Dim handler As JwtSecurityTokenHandler = New JwtSecurityTokenHandler()
      Dim tokenS = handler.ReadToken(pTK)
      Dim validoHasta = tokenS.ValidTo

      Dim span As TimeSpan = fechaCR(validoHasta).Subtract(Now)
      Return span.ToString("mm\:ss")

   End Function

   Function fechaCR(fechaUTC As DateTime) As DateTime
      Dim time2 As TimeZone = TimeZone.CurrentTimeZone
      Dim test As DateTime = time2.ToUniversalTime(fechaUTC)
      Dim CR = TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time")
      Dim horaCR = TimeZoneInfo.ConvertTimeFromUtc(test, CR)
      Return horaCR
   End Function

   Public Sub ActLabel(ByVal pMsg As HttpResponseMessage)
        If pMsg IsNot Nothing Then
            If Me.lbReinicio.InvokeRequired Then
                Dim d As New MensajeCallBackHeaders(AddressOf ActLabel)
                Me.Invoke(d, New Object() {pMsg})
            Else

                Dim fechaReinicio = UnixTimeStampToDateTime(CDbl(pMsg.Headers.GetValues("X-Ratelimit-Reset").FirstOrDefault))

                lbReinicio.Text = "reincio: " & fechaReinicio.ToShortDateString & " " & fechaReinicio.TimeOfDay.ToString
                lbDisponible.Text = pMsg.Headers.GetValues("X-Ratelimit-Remaining").FirstOrDefault
                lbTotal.Text = pMsg.Headers.GetValues("X-Ratelimit-Limit").FirstOrDefault


                My.Settings.peticionesSobran = CInt(lbDisponible.Text)
                My.Settings.petisionesLimite = CInt(lbTotal.Text)
                My.Settings.peticionesReinicio = lbReinicio.Text
                My.Settings.Save()
            End If

        End If
    End Sub

    Public Shared Function UnixTimeStampToDateTime(ByVal unixTimeStamp As Double) As DateTime
      ' Unix timestamp is seconds past epoch
      Dim dtDateTime As Date = New DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
      dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime
      Return dtDateTime
   End Function


   Function HayInternet() As Boolean
      Try
         Return My.Computer.Network.Ping("8.8.8.8", 10000)
      Catch ex As Exception
         Return False
      End Try

   End Function

   Public Function HayCorreo() As Boolean
      Try
         Dim emailH As String = cnf.Item("emailHost")

         If HayInternet() And emailH <> "" Then
            Return My.Computer.Network.Ping(emailH, 1000)
         End If
         Return False
      Catch ex As Exception
         Return False
      End Try
   End Function

   Public Function HayAPI() As Boolean
        Try
            Dim webClient As New System.Net.WebClient
            Dim result As String = webClient.DownloadString("http://apis.gometa.org/status/status.json")

            Dim StatusAPI = JsonConvert.DeserializeObject(Of gometa_status)(result)

            If StatusAPI.ApiProd.Status = "BAD" Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

   Public Function HayServidorWEB() As Boolean
      Try
         If HayInternet() And cnf.Item("ftpHost") <> "" Then
            Dim _rep As Boolean = False
            Dim URIweb As Uri = New Uri(cnf.Item("ftpHost"))
            Return My.Computer.Network.Ping(URIweb.Host, 1000)
         End If
         Return False
      Catch ex As Exception
         Return False
      End Try
   End Function

   Public Function HayBD() As Boolean
      Try
         Using connection As New SqlClient.SqlConnection(cnf.Item("connSQL"))
            connection.Open()
            Return (connection.State = ConnectionState.Open)
         End Using

      Catch ex As Exception
         Return False
      End Try

   End Function

   Public Function HaySistemas() As Boolean
      Return HayAPI() And HayBD() And HayCorreo() And HayServidorWEB()
   End Function

   Private Overloads Function HayCertificado() As Boolean
      Try
         Dim resp = File.Exists(CSA_config.llaveRuta)
         Return resp
      Catch ex As Exception
         Return False
      End Try
   End Function

    Public Sub ActLog(ByVal pMsg As String)
        Dim fecha As String = Now.ToString("dd/mm/yyyy | hh\:mm\:ss } ")

        If Me.TextBoxResult.InvokeRequired Then
            Dim d As New MensajeCallBack(AddressOf ActLog)
            Me.Invoke(d, New Object() {pMsg})
        Else

            TextBoxResult.Text += fecha & pMsg & vbCrLf
        End If
    End Sub
#End Region


#Region " Metodos del Formulario"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SwitchButton1.Visible = False
        SwitchButton2.Value = (My.Settings.emisor_servidor = "api-prod") 'verifica estado y ajusta switch grafico

    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

      NotifyIcon1.Visible = False
      NotifyIcon1 = Nothing
      My.Settings.Save()

   End Sub
   ''' <summary>
   ''' 
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Cargar_Configuracion()

        If CSA_config.apiUsuario.Contains("stag.") Then
         Dim valor As Boolean = True
         lbTotal.Visible = valor
         lbDisponible.Visible = valor
         lbReinicio.Visible = valor
      Else
         Dim valor As Boolean = False
         lbTotal.Visible = valor
         lbDisponible.Visible = valor
         lbReinicio.Visible = valor
      End If

      MicroChart1.Text = "Factura: "
      MicroChart1.ChartType = eMicroChartType.HundredPercentBar

      MicroChart1.HundredPctChartStyle.BarColors(0) = Color.OrangeRed
      MicroChart1.HundredPctChartStyle.BarColors(1) = Color.LightBlue
      MicroChart1.HundredPctChartStyle.BarColors(2) = Color.Orange
      MicroChart1.HundredPctChartStyle.BarColors(3) = Color.LightGreen

      Dim conn As New ConexionSQL(cnf.Item("connSQL"))
      Dim tabla = conn.llenaTabla("SELECT confirmacion, count(id) cantidad FROM [fact.factura] where confirmacion is not null group by confirmacion")

      For Each reg In tabla.Rows
         If reg.item("confirmacion") <> "aceptado" Then

            MicroChart1.DataPoints.Add(reg.item("cantidad"))
            MicroChart1.DataPointTooltips.Add(reg.item("confirmacion") & ": " & reg.item("cantidad").ToString)
         End If
      Next

        '' verifica si Hay sistema
        BackgroundWorker1.RunWorkerAsync()

        '? //////////////////////////////////////////////////////////////////
        Try   ' Inicia hilo de ejecucion de envio
         hiloFactura.IsBackground = True
         hiloFactura.Name = "Genera Facturas"
         hiloFactura.Start()
         Me.SwitchButton1.Visible = True
      Catch ex As Exception
         MessageBox.Show("Error al cargar Hilo")
      End Try

   End Sub



   ''' <summary>
   ''' Evita cerrar la apicacion
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
      Me.WindowState = FormWindowState.Minimized
      Me.Visible = False
      NotifyIcon1.Visible = True
      e.Cancel = True
   End Sub


   Private Sub NotifyIcon1_MouseClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseClick

      If Not e.Button = Windows.Forms.MouseButtons.Right Then
         Me.Visible = Not Me.Visible
         Me.WindowState = IIf(Me.Visible, FormWindowState.Normal, FormWindowState.Minimized)
      End If

   End Sub


   Private Sub SwitchButton1_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton1.ValueChanged

#Disable Warning BC40000 ' El tipo o el miembro están obsoletos
      If hiloFactura.IsAlive Then
         If CircularProgress1.IsRunning Then
            hiloFactura.Suspend()
            ComboBoxEx1.Enabled = True
            SwitchButton2.Enabled = True
         Else
            If hiloFactura.ThreadState = ThreadState.Suspended Then
               hiloFactura.Resume()
            End If
            ComboBoxEx1.Enabled = False
            SwitchButton2.Enabled = False

         End If
      End If
#Enable Warning BC40000 ' El tipo o el miembro están obsoletos

      CircularProgress1.IsRunning = SwitchButton1.Value
   End Sub

   Private Sub SuperTabControl1_SelectedTabChanging(sender As Object, e As SuperTabStripSelectedTabChangingEventArgs) Handles SuperTabControl1.SelectedTabChanging
      My.Settings.Save()
   End Sub

   ''' <summary>
   '''  se desplaza al final del texto
   ''' </summary>
   ''' <param name="sender"></param>
   ''' <param name="e"></param>
   Private Sub TextBoxResult_TextChanged(sender As Object, e As EventArgs) Handles TextBoxResult.TextChanged
      TextBoxResult.SelectionStart = TextBoxResult.Text.Length
      TextBoxResult.ScrollToCaret()
      TextBoxResult.Refresh()
   End Sub

   Private Sub SuperTabItem1_Click(sender As Object, e As EventArgs) Handles SuperTabItem1.Click
      If Not BackgroundWorker1.IsBusy Then
         BackgroundWorker1.RunWorkerAsync()
      End If

   End Sub

   Private Sub CircularProgress1_MouseClick(sender As Object, e As MouseEventArgs) Handles CircularProgress1.MouseClick
      Application.Exit()
   End Sub

#End Region


#Region " Hilo de estados de conexion"
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
      cbWEB.Checked = False
      cbInternet.Checked = False
      cbBD.Checked = False
      cbEmail.Checked = False
      cbAPI.Checked = False
      cbCertificado.Checked = False

      cbWEB.Checked = HayServidorWEB()
      cbInternet.Checked = HayInternet()
      cbBD.Checked = HayBD()
      cbEmail.Checked = HayCorreo()
      cbAPI.Checked = HayAPI()
      cbCertificado.Checked = HayCertificado()
   End Sub

   Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
      NotifyIcon1.Visible = False
      Application.Exit()
   End Sub

    Private Sub SwitchButton2_ValueChanged(sender As Object, e As EventArgs) Handles SwitchButton2.ValueChanged
        Guarda_Datos_Emisor()
    End Sub


    Private Sub ComboBoxEx1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxEx1.SelectedIndexChanged
      Guarda_Datos_Emisor()
   End Sub

   Sub Guarda_Datos_Emisor()

        If ComboBoxEx1.SelectedValue IsNot Nothing Then
            My.Settings.emisor = ComboBoxEx1.SelectedValue
            My.Settings.emisor_servidor = IIf(SwitchButton2.Value, "api-prod", "api-stag")
            My.Settings.Save()

            '? Carga la nueva configuracion
            Cargar_Configuracion()
        End If
    End Sub

    Sub Cargar_Configuracion()

      'TODO: esta línea de código carga datos en la tabla 'EFacturaDataSet.Emisores' Puede moverla o quitarla según sea necesario.
      Me.EmisoresTableAdapter.Fill(Me.EFacturaDataSet.Emisores)

      Dim connSQL As New ConexionSQL("Data Source=servidor-bd;Initial Catalog=Facturacion;User ID=colegiosa;Password=C$@123")
      Dim sqlconf As String = $"SELECT Servidores.*,Emisores.* FROM Emisores INNER JOIN Servidores ON Emisores.id = Servidores.emisor WHERE numeroID = '{My.Settings.emisor}' AND ClientID = '{ My.Settings.emisor_servidor}' "

      Dim tabladb = connSQL.llenaTabla(sqlconf)
      If tabladb IsNot Nothing Then

         cnf = tabladb.Rows(0)

         CSA_config = New confComunicacion With {
               .apiUsuario = cnf.Item("usuario"),
               .apiClave = cnf.Item("clave"),
               .apiURL = cnf.Item("API"),
               .apiIDP = cnf.Item("IDP"),
               .llaveRuta = cnf.Item("rutaLLave"),
               .llavePIN = cnf.Item("pinLLave")
            }

         conn = New ConexionSQL(cnf.Item("connSQL"))
         My.Settings.eFacturaConnection = cnf.Item("connSQL")

      Else
         ActLog("ERROR :" & "configuracion no cargada")
      End If

        If Not HayCertificado() Then
         ActLog("ERROR :" & "Llave no encontrada")
         SwitchButton1.Value = False
      End If

      If Not Directory.Exists(cnf.Item("rutaArch")) Then
         ActLog("ERROR :" & "Carperta de respaldo no existe")
         SwitchButton1.Value = False
      End If

      lbTotal.Text = My.Settings.petisionesLimite
      lbDisponible.Text = My.Settings.peticionesSobran
      lbReinicio.Text = My.Settings.peticionesReinicio

      '? verifica si hay sistema
      If BackgroundWorker1.IsBusy Then
         BackgroundWorker1.CancelAsync()

         BackgroundWorker1.RunWorkerAsync()
      End If
   End Sub

#End Region

End Class
