'' FirmaElectronicaCR es un programa para la firma y envio de documentos XML para la Factura Electrónica de Costa Rica
''
'' Comunicacion es la clase para el envío del documento XML para la Factura Electrónica de Costa Rica
''
'' Esta clase de Firma fue realizado tomando como base el trabajo realizado por:
'' - Departamento de Nuevas Tecnologías - Dirección General de Urbanismo Ayuntamiento de Cartagena
'' - XAdES Starter Kit desarrollado por Microsoft Francia
'' - Cambios y funcionalidad para Costa Rica - Roy Rojas - royrojas@dotnetcr.com
''
'' La clase comunicación fue creada en conjunto con Cristhian Sancho
''
'' Este programa es software libre: puede redistribuirlo y / o modificarlo
'' bajo los + términos de la Licencia Pública General Reducida de GNU publicada por
'' la Free Software Foundation, ya sea la versión 3 de la licencia, o
'' (a su opción) cualquier versión posterior.

'' Este programa se distribuye con la esperanza de que sea útil,
'' pero SIN NINGUNA GARANTÍA; sin siquiera la garantía implícita de
'' COMERCIABILIDAD O IDONEIDAD PARA UN PROPÓSITO PARTICULAR.
'' Licencia pública general menor de GNU para más detalles.
''
'' Deberías haber recibido una copia de la Licencia Pública General Reducida de GNU
'' junto con este programa. Si no, vea http://www.gnu.org/licenses/.
''
'' This program Is distributed in the hope that it will be useful,
'' but WITHOUT ANY WARRANTY; without even the implied warranty of
'' MERCHANTABILITY Or FITNESS FOR A PARTICULAR PURPOSE.  See the
'' GNU Lesser General Public License for more details.
''
'' You should have received a copy of the GNU Lesser General Public License
'' along with this program.  If Not, see http://www.gnu.org/licenses/. 

Imports System.Net.Http
Imports System.Threading
Imports Newtonsoft.Json.Linq

Public Class Comunicacion

    Public Property xmlRespuesta As Xml.XmlDocument
    Public Property jsonEnvio As String = ""
    Public Property jsonRespuesta As String = ""
    Public Property mensajeRespuesta As String = ""
    Public Property estadoFactura As String = ""
    Public Property statusCode As String = ""

    Public Property ComprobanteLista As List(Of Comprobante)
    Public Property Comprobante As Comprobante
    Public Property response As HttpResponseMessage


    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    ''' <summary>   Define el servidor para enviar los datos. </summary>
    ''' Define el servidor para enviar los datos
    ''' <value> The URL recepcion.  Default : "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/" </value>
    '''////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Property URL_RECEPCION As String = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/"

    ''' <summary>
    ''' Envia los datos a los servidores de Hacienda y obtiene las respuestas necesarias
    ''' </summary>
    ''' <param name="TK">Token que generó Hacienda</param>
    ''' <param name="objRecepcion">Objeto que contiene todos las variables de comunicación</param>
    Public Sub EnvioDatos(TK As String, ByVal objRecepcion As Recepcion)

        Dim http As HttpClient
        Dim res As String

        ' ? ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Try   '' envia XML
            http = New HttpClient
            Dim JsonObject As Newtonsoft.Json.Linq.JObject = New Newtonsoft.Json.Linq.JObject()
            JsonObject.Add(New JProperty("clave", objRecepcion.clave))
            JsonObject.Add(New JProperty("fecha", objRecepcion.fecha))
            JsonObject.Add(New JProperty("emisor", New JObject(New JProperty("tipoIdentificacion", objRecepcion.emisor.TipoIdentificacion),
                                                               New JProperty("numeroIdentificacion", objRecepcion.emisor.numeroIdentificacion))))

            If objRecepcion.receptor.sinReceptor = False Then
                JsonObject.Add(New JProperty("receptor", New JObject(New JProperty("tipoIdentificacion", objRecepcion.receptor.TipoIdentificacion),
                                                                     New JProperty("numeroIdentificacion", objRecepcion.receptor.numeroIdentificacion))))
            End If
            JsonObject.Add(New JProperty("comprobanteXml", objRecepcion.comprobanteXml))
            jsonEnvio = JsonObject.ToString

            Dim oString As StringContent = New StringContent(JsonObject.ToString)
            http.DefaultRequestHeaders.Add("authorization", "Bearer " + TK)

            response = http.PostAsync(URL_RECEPCION + "recepcion", oString).Result
            res = response.Content.ReadAsStringAsync.Result          '/////////////////// envia documentos xml
            statusCode = response.StatusCode

        Catch ex As Exception
            response = New HttpResponseMessage(Net.HttpStatusCode.Forbidden)
        End Try
    End Sub

    Public Sub ConsultaEstatus(TK As String, claveConsultar As String)
        Try
            Dim http As HttpClient = New HttpClient
            http.DefaultRequestHeaders.Add("authorization", "Bearer " + TK)

            Dim response As HttpResponseMessage = http.GetAsync(URL_RECEPCION & "recepcion/" & claveConsultar).Result
            Dim res As String = response.Content.ReadAsStringAsync.Result

            Select Case response.StatusCode
                Case 200 To 299
                    jsonRespuesta = res.ToString

                    Dim RH As RespuestaHacienda = Newtonsoft.Json.JsonConvert.DeserializeObject(Of RespuestaHacienda)(res)

                    If RH.respuesta_xml <> "" Then
                        xmlRespuesta = Funciones.DecodeBase64ToXML(RH.respuesta_xml)
                    End If

                    estadoFactura = RH.ind_estado
                    statusCode = response.StatusCode

                    mensajeRespuesta = "Confirmación: " & statusCode & "Estado: " & estadoFactura
                Case Else

                    Dim errorGet = response.Headers.GetValues("X-Error-Cause").FirstOrDefault
                    mensajeRespuesta = "Confirmación: " & errorGet & vbCrLf
            End Select

        Catch ex As Exception
            Throw New Exception(ex.Message)
      End Try
    End Sub



    Public Sub ComprobanteBusca(TK As String, Optional claveConsultar As String = "")
        Try

            Dim http As HttpClient = New HttpClient
            http.DefaultRequestHeaders.Add("authorization", "Bearer " + TK)

            Dim _consulta As String = URL_RECEPCION & "comprobantes/"
            If (claveConsultar <> "") Then  '' si hay numero de clave consulta
                _consulta += claveConsultar
            End If


            Dim tokenSource = New CancellationTokenSource()
            tokenSource.CancelAfter(TimeSpan.FromSeconds(15))

            Dim response As HttpResponseMessage = http.GetAsync(_consulta, tokenSource.Token).Result
            Dim res As String = response.Content.ReadAsStringAsync.Result

            jsonRespuesta = res.ToString
            Dim RH As Comprobante = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Comprobante)(res)

         Select Case response.StatusCode
            Case 200 To 299
               jsonRespuesta = res.ToString
               statusCode = response.StatusCode
               Comprobante = RH

               mensajeRespuesta = "Confirmación: " & statusCode & vbCrLf
            Case 404
               statusCode = response.StatusCode
               Dim errorGet = response.Headers.GetValues("X-Error-Cause").FirstOrDefault
               mensajeRespuesta = errorGet
               jsonRespuesta = mensajeRespuesta
            Case Else
               statusCode = response.StatusCode
               mensajeRespuesta = response.ReasonPhrase
               jsonRespuesta = mensajeRespuesta
         End Select

      Catch ex As Exception
         statusCode = "400"
         Comprobante = Nothing

         If ex.InnerException IsNot Nothing Then
            mensajeRespuesta = ex.InnerException.Message
         Else
            mensajeRespuesta = ""
         End If
         'Throw
      End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TK"> Token para consultar </param>
    ''' <param name="ini">   A partir de que posición contar los items a retornar 'Example: 10 </param>
    ''' <param name="cantidad"> A partir de que posición contar los items a retornar  'Example: 15</param>
    ''' <param name="emisor">Cantidad de items a retornar apartir del offset 'Example: 02003101123456</param>
    ''' <param name="receptor"> Tipo y número de identificación del emisor. 'Example: 02003101123456 </param>
    Public Sub Comprobantes_Receptor(TK As String, ini As Integer, cantidad As Integer, emisor As String, receptor As String)
        Try

            Dim http As HttpClient = New HttpClient
            http.DefaultRequestHeaders.Add("authorization", "Bearer " + TK)

            ' crea consulta
            'Dim _parametrosURI As String = String.Format("?offset={0}&limit={1}&emisor={2}&receptor={3}", ini, cantidad, emisor, receptor)
            Dim _parametrosURI As String = String.Format("?emisor={0}&receptor={1}", emisor, receptor)


            Dim _consulta As String = URL_RECEPCION & "comprobantes" & _parametrosURI

            Dim response As HttpResponseMessage = http.GetAsync(_consulta).Result
            Dim res As String = response.Content.ReadAsStringAsync.Result

            Select Case response.StatusCode
                Case 200 To 299
                    jsonRespuesta = res.ToString
                    Dim RH As List(Of Comprobante) = Newtonsoft.Json.JsonConvert.DeserializeObject(Of List(Of Comprobante))(res)

                    statusCode = response.StatusCode
                    ComprobanteLista = RH

                    mensajeRespuesta = "Confirmación: " & statusCode & vbCrLf
                Case Else

                    Dim errorGet = response.Headers.GetValues("X-Error-Cause").FirstOrDefault
                    mensajeRespuesta = "Confirmación: " & errorGet & vbCrLf
            End Select


        Catch ex As Exception
            Throw
        End Try

        '   Query Parameters para comprobantes de un receptor
        'offset: (integer)   A partir de que posición contar los items a retornar
        'Example: 10

        'limit: (integer - default: 50)  Cantidad de items a retornar apartir del offset
        'Example: 15

        'emisor: (string - maxLength: 14) Tipo y número de identificación del emisor.
        'Example: 02003101123456

        'receptor: (string - maxLength: 14) Tipo y número de identificación del receptor.
        'Example: 02003101123456
    End Sub

   Function getValorHeader(Respuesta As HttpResponseMessage, etiqueta As String) As Object
      Try
         Return Respuesta.Headers.GetValues(etiqueta).FirstOrDefault

      Catch ex As Exception
         Throw New Exception(ex.Message)
      End Try
   End Function



End Class
