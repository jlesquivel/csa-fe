Imports EG.EnviaFactura


Public Class prueba_EnviaHda



    Public Shared Sub Main()

        Dim CSAprueba As New confComunicacion With {
            .apiUsuario = "cpj-3-002-182080@stag.comprobanteselectronicos.go.cr",
            .apiClave = "ucheq:;VA&P2.:+>-L&+",
            .apiURL = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/",
            .apiIDP = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token",
            .llaveRuta = "D:\eFactura\cert\CSA_sandbox\300218208010.p12",
            .llavePIN = "1956"
        }

        Try

            'Dim ruta = "D:\eFactura\xml_pdf\"
            'Dim archivo = "50612121800300218208000100001010000000060189611703"

            'Dim envia = New enviaHacienda(ruta & archivo & ".xml", CSAprueba)

            'If envia.HayInternet Then
            '    'Console.WriteLine(envia.Procesa()) 

            '    'Console.WriteLine(envia.consulta())

            '    Dim comprobante As Comprobante = envia.comprobante(archivo)

            '    Console.ReadKey()

            'Else
            '    Console.WriteLine("no hay conexión Internet")
            'End If

            'Console.ReadKey()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try



    End Sub

End Class
