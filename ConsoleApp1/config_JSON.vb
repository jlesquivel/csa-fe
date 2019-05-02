Imports Newtonsoft.Json

Friend Module config_JSON
   Public Sub Main()

      Console.WriteLine("  ****  INICIADO config JSON")
      Try

         Dim configs As New Configuracion
         configs.Load()

         Dim config1 As New Iconfiguracion With {.id = "1", .Emisor = "jose", .PIN = "123", .NombreComercial = ""}

         configs.Agregar("1", config1)
         configs.Agregar("2", config1)

         Dim res = configs.Buscar("2").ToString("!")

         Console.WriteLine(res)

         Console.ReadKey()
      Catch ex As Exception

      End Try
   End Sub

   Public Class Configuracion

      ''' <summary>
      ''' 
      ''' </summary>
      ''' <returns></returns>
      Public Property Configuraciones As New ArrayList
      Private ReadOnly rutaDefault As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) & "\f_electron-setting.json"

      Public Sub Agregar(id As String, datos As Iconfiguracion)

         Dim res = Buscar(id)
         If res IsNot Nothing Then
            Configuraciones.Remove(res)
         End If

         Configuraciones.Add(datos)
         Save()

      End Sub

      Public Sub Remover(id)

         Dim res = Buscar(id)
         If res IsNot Nothing Then
            Configuraciones.Remove(res)
         End If
         Save()

      End Sub

      ''' <summary>
      ''' 
      ''' </summary>
      ''' <param name="item"></param>
      ''' <returns></returns>
      Public Function Buscar(item As String) As Iconfiguracion

         For i = 0 To Configuraciones.Count - 1
            ' Código
            If Configuraciones(i).id = item Then
               Return Configuraciones(i)
            End If
         Next i

         Return Nothing
      End Function

      ''' <summary>
      ''' guarda el archivo Json
      ''' </summary>
      Public Sub Save(Optional ruta As String = "")
         Dim str As String = JsonConvert.SerializeObject(Configuraciones)
         ruta = IIf(ruta = "", rutaDefault, ruta)
         My.Computer.FileSystem.WriteAllText(ruta, str, False)
      End Sub
      ''' <summary>
      '''  Carga el archivo json con las cofiguraciones
      ''' </summary>
      Public Sub Load(Optional ruta As String = "")

         ruta = IIf(ruta = "", rutaDefault, ruta)
         If System.IO.File.Exists(ruta) Then
            Dim filer As String = My.Computer.FileSystem.ReadAllText(ruta)
            Dim obj = JsonConvert.DeserializeObject(Of List(Of Iconfiguracion))(filer)
            Configuraciones = New System.Collections.ArrayList(obj)
         Else
            'the file doesn't exist
            Throw New System.Exception("Archivo configuracion no existe.")
         End If
      End Sub

   End Class


   Public Class Iconfiguracion

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
         Return String.Format("{0} {1}", id, NombreComercial)

      End Function

   End Class


End Module
