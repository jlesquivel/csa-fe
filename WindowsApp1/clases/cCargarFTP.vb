Imports System.IO
Imports System.Net
Imports System.Text

Public Class cCargarFTP

    Private urlFtp1 As String
    Private userName1 As String
    Private password1 As String


    Public Property UrlFtp As String
        Get
            Return urlFtp1
        End Get
        Set(value As String)
            urlFtp1 = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return password1
        End Get
        Set(value As String)
            password1 = value
        End Set
    End Property

    Public Property UserName As String
        Get
            Return userName1
        End Get
        Set(value As String)
            userName1 = value
        End Set
    End Property

    Sub New(url As String, user As String, pass As String)
        urlFtp1 = url
        userName1 = user
        password1 = pass
    End Sub

    Function enviar(archivo As String) As FtpWebResponse

        Try

            If File.Exists(archivo) Then
                ' Get the object used to communicate with the server.
                Dim _uploadFilename = Path.GetFileName(archivo)
                Dim _ftpArchivo = $"{urlFtp1}{_uploadFilename}"
                Dim request As FtpWebRequest = CType(WebRequest.Create(_ftpArchivo), FtpWebRequest)
                request.Method = WebRequestMethods.Ftp.UploadFile

                ' This example assumes the FTP site uses anonymous logon.
                request.Credentials = New NetworkCredential(userName1, password1)

                ' Copy the contents of the file to the request stream.
                Dim fileContents As Byte() = System.IO.File.ReadAllBytes(archivo)
                'Using sourceStream As StreamReader = New StreamReader(archivo)
                '    fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd())
                'End Using
                request.ContentLength = fileContents.Length

                Using requestStream As Stream = request.GetRequestStream()
                    requestStream.Write(fileContents, 0, fileContents.Length)
                End Using

                Using response As FtpWebResponse = CType(request.GetResponse(), FtpWebResponse)
                    'Console.WriteLine($"Upload File Complete, status {response.StatusDescription}")
                    Return response
                End Using
            Else
                Logger.w("Error al enviar archivo via FTP", New StackFrame(True))
                Return Nothing
            End If
        Catch ex As Exception

            Logger.e("Error cCargarFTP.enviar", ex, New StackFrame(True))
            Return Nothing

        End Try
    End Function

End Class
