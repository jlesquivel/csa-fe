Imports Newtonsoft.Json

Public Class CConfiguracion

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

