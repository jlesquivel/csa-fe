Public Class IConfiguracion

   Public Property Id As String

   Public Property EmailHost As String
   Public Property Emailport As String
   Public Property EmailSend As String
   Public Property EmailSendPass As String
   Public Property EmailBody As String
   Public Property EmailNombre As String

   Public Property FtpHost As String
   Public Property FtpUser As String
   Public Property FtpPass As String

   Public Property RutaArchivos As String
   Public Property APIToken As String

   Public Property ConnSQL As String
   Public Property FacturasParalelas As String


   Public Property Emisor As String
   Public Property NombreComercial As String
   Public Property Usuario As String
   Public Property Clave As String
   Public Property Certificado As String
   Public Property PIN As String


   Public Overloads Function ToString(fmt As String) As String
      Return String.Format("{0} {1}", Id, NombreComercial)

   End Function

End Class

