Imports System.Threading
Imports EG.EnviaFactura
Imports CR.FacturaElectronica
Imports EG.CajaHerramientas
Imports System.Data.SqlClient
Imports System.Net.Http

Public Class GestionaFactura

   Private _doneEvent As ManualResetEvent

   Public ReadOnly Property idFact As Integer
   Public ReadOnly Property emisor As confComunicacion

   Public Property respuesta As String = ""
   Public Property resultado As String = ""
   Public Property resultadoCorreo As String = ""

   Public Property MensajeError As String = ""
    Public Property strConexion As ConexionSQL
    Public Property response As HttpResponseMessage

    Private TK As String   ' token
   Private cnf As DataRow


   Public Sub New(_emisor As confComunicacion, _idFactura As Integer, pcnf As DataRow, pTK As String, doneEvent As ManualResetEvent)

      cnf = pcnf     '' carga configuracion desde BD , recivido por el parametro

      Me.strConexion = New ConexionSQL(cnf.Item("connSQL"))
      Me.idFact = _idFactura
      Me.emisor = _emisor
      Me.TK = pTK

      _doneEvent = doneEvent
   End Sub

   Public Sub GeneraFactura(threadContext As Object)

      Dim threadIndex As Integer = CType(threadContext, Integer)
      Dim res As RespuestaCreacionDoc
      Dim rutaArchivos As String = ""


        Try
            Dim conn As New ConexionSQL(cnf.Item("connSQL"))

            '? /////////////////////////////////////////////////////////////////////////////////////////////// GENERA XML

            Dim facturar As New cFactura With {.rutaArchivos = cnf.item("rutaArch")}
            res = facturar.GenerarXML(idFact)                       '*******************  GENERA XML

            If res.ClaveDocCreada IsNot Nothing Then

                rutaArchivos = facturar.rutaArchivos & IIf(facturar.rutaArchivos.EndsWith("\"), "", "\")

                '? ///////////////////////////////////////////////////////////////////////////////////////// Actualiza consecutivo y clave
                Dim actFact = "UPDATE [fact.factura] SET enc_clave = '$valor' , enc_consecutivo = '$consect' WHERE (id = $idFact)"
                actFact = actFact.Replace("$valor", res.ClaveDocCreada)
                actFact = actFact.Replace("$consect", res.ConsecutivoDocCreado)
                actFact = actFact.Replace("$idFact", idFact.ToString)
                conn.ejecuta(actFact)

                '? ////////////////////////////////////////////////////////////////////////////////////////  Genera QR y PDF 
                Dim pdf = New cPDF With {.clave = res.ClaveDocCreada}
                pdf.salvarQR(idFact)
                pdf.GenerarPDf(rutaArchivos, res.ClaveDocCreada, idFact, My.Settings.emisor_servidor)
            End If


            '?/////////////////////////////////////////////////////////////////////////////////////////////////// ENVIA HACIENDA

            Dim envia As Object

            envia = New enviaHacienda(res.archivo, emisor, TK)
            respuesta = envia.Procesa()
            response = envia.response

            resultado = envia.estado
            respuesta = envia.respuestaHacienda
            MensajeError = ""

            Select Case envia.estado
                Case "recibido"
                    ActualizaBD(idFact, envia.estado, envia.respuestaHacienda)
                Case "aceptado"
                    'todo REVISAR BIEN EL ENVIO DE CORREO DA ERRORES GRAVES

                    EnviaCorreo(idFact, rutaArchivos, res.ClaveDocCreada)
                    ActualizaBD(idFact, envia.estado, "")
                Case "procesando"
                    ActualizaBD(idFact, envia.estado, "")
                Case "rechazado"
                    MensajeError = envia.respuestaHacienda
                    ActualizaBD(idFact, envia.estado, envia.respuestaHacienda)
                Case "error"
                    MensajeError = envia.respuestaHacienda
                    ActualizaBD(idFact, "error", envia.respuestaHacienda)
                Case Else
                    If envia.estado Is Nothing Then
                        MessageBox.Show(envia.ToString)
                    End If
                    ActualizaBD(idFact, "error", "")
            End Select

            ' cargar el archivo PDF al servidor web CSALIB.ORG
            Dim ftpCSALIB As New cCargarFTP(cnf.Item("ftpHost"), cnf.Item("ftpuser"), cnf.Item("ftpPass"))
            Dim ftpCSALIB2 As New cCargarFTP(cnf.Item("ftpHost"), cnf.Item("ftpuser"), cnf.Item("ftpPass"))

            ftpCSALIB.enviar(rutaArchivos & res.ClaveDocCreada & ".xml")
            ftpCSALIB2.enviar(rutaArchivos & res.ClaveDocCreada & ".pdf")

            ftpCSALIB = Nothing
            ftpCSALIB2 = Nothing

        Catch ex As Exception
            'TODO Corregir problema al detectar error en ftpCSALIB.enviar
            'Throw New Exception("GestionaFactura.GeneraFactura " + ex.Message)

            Logger.e("Error con excepción y traza", ex, New StackFrame(True))
        End Try
        _doneEvent.Set()

   End Sub

   Function EnviaCorreo(factura As Integer, ruta As String, clave As String) As String
      Try
         '? Enviar por correo el archivo 
         Dim correo As New cCorreo With {.cnf = cnf}
         correo.enviar(factura, ruta, clave, emisor)
         Return correo.statusEnvio

      Catch ex As Exception
         Throw
      End Try

   End Function

   Sub ActualizaBD(idFact As Integer, pEstado As String, pMsg As String)
      '?  actualizar en base de datos que fue enviado correo,
      Try
         pMsg = pMsg.Replace("'", "")  'elimina caracteres para poder insertar
         Dim instSQL = $"UPDATE [fact.factura] SET confirmacion = '{pEstado}',confirmacionMsg = N'{pMsg}' where id = {idFact} "
         strConexion.ejecuta(instSQL)

      Catch ex As Exception
         Throw
      End Try
   End Sub

End Class
