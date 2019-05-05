Imports System.Threading
Imports EG.EnviaFactura
Imports CR.FacturaElectronica
Imports EG.CajaHerramientas
Imports System.Data.SqlClient
Imports System.Net.Http
Imports System


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

                Dim femision As DateTime = DateTime.Now


                Dim actFact = "UPDATE [fact.factura] SET enc_clave = '$valor' , enc_consecutivo = '$consect', enc_fecha = CONVERT(DATETIME, '$fechaCreacion')  WHERE (id = $idFact)"
                actFact = actFact.Replace("$valor", res.ClaveDocCreada)
                actFact = actFact.Replace("$consect", res.ConsecutivoDocCreado)
                actFact = actFact.Replace("$idFact", idFact.ToString)
                actFact = actFact.Replace("$fechaCreacion", res.FechaEmision.ToString("MM/dd/yyyy HH:mm:ss:fff"))
                conn.ejecuta(actFact)

                '? ////////////////////////////////////////////////////////////////////////////////////////  Genera QR y PDF 
                Dim pdf = New cPDF With {.clave = res.ClaveDocCreada}
                pdf.salvarQR(idFact)
                pdf.GenerarPDf(rutaArchivos, res.ClaveDocCreada, idFact, My.Settings.emisor_servidor)
            End If

            '?/////////////////////////////////////////////////////////////////////////////////////////////////// ENVIA HACIENDA

            Dim envia = New enviaHacienda(res.archivo, emisor, TK)
            respuesta = envia.Procesa()
            response = envia.response

            resultado = response.ReasonPhrase
            respuesta = envia.respuestaHacienda
            MensajeError = ""

            If response.IsSuccessStatusCode Then
                Dim instSQL = $"UPDATE [fact.factura] SET confirmacion = '{response.ReasonPhrase}' where id = {idFact} "
                strConexion.ejecuta(instSQL)
            End If

        Catch ex As Exception
            'TODO Corregir problema al detectar error en ftpCSALIB.enviar
            'Throw New Exception("GestionaFactura.GeneraFactura " + ex.Message)

            Logger.e("Error con excepción y traza", ex, New StackFrame(True))
        End Try
        _doneEvent.Set()

    End Sub

End Class
