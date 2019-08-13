Imports EG.EnviaFactura
Imports System.Net.Http


Public Class GestionaMensajeReceptor

   Public ReadOnly Property idMensajeReceptor As Integer
   Public ReadOnly Property emisor As confComunicacion

   Public Property respuesta As String = ""
   Public Property resultado As String = ""
   Public Property resultadoCorreo As String = ""

   Public Property MensajeError As String = ""
   Public Property strConexion As ConexionSQL
   Public Property response As HttpResponseMessage

   Private TK As String   ' token
   Private cnf As DataRow

   Public Sub New(_emisor As confComunicacion, pcnf As DataRow, pTK As String)

      cnf = pcnf     '' carga configuracion desde BD , recivido por el parametro

      Me.strConexion = New ConexionSQL(cnf.Item("connSQL"))
      Me.emisor = _emisor
      Me.TK = pTK

   End Sub


   Public Sub EnviaMensajeReceptor(_idMensajeReceptor As Integer)

      Try
         '! GENERA XML DEL MENSAJE RECEPTOR
         '!----------------------------------------------------------
         Dim OMReceptor As New CMensajeReceptor(cnf)
         Dim res = OMReceptor.GenerarXML(_idMensajeReceptor)


         '! ENVIA  MENSAJE RECEPTOR A HACIENDA
         '!----------------------------------------------------------
         Dim envia = New enviaHacienda(Res.archivo, emisor, TK)
         respuesta = envia.Procesa()
         response = envia.response

         resultado = response.ReasonPhrase
         respuesta = envia.respuestaHacienda
         MensajeError = ""

         If response.IsSuccessStatusCode Then
            '? ojo ACATUALIZAR BASE DE DATOS QUE SE ENVIO CORRECTAMENTE
            'Dim instSQL = $"UPDATE [fact.factura] SET confirmacion = '{response.ReasonPhrase}' where id = {idFact} "
            'strConexion.ejecuta(instSQL)
         End If

         '! ENVIA  MENSAJE RECEPTOR A RECEPRO POR EMAIL
         '!----------------------------------------------------------

         '? FALTA OJOOOOOOOOOO


      Catch ex As Exception
         Logger.e("Error con excepción y traza", ex, New StackFrame(True))
         Throw ex
      End Try
   End Sub


End Class
