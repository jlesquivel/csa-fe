Imports System.IO
Imports System.Net.Http

Public Class enviaHacienda


   Public Property archivo
   Public Property certificado As String
   Public Property PIN As String

   Public Property Clave As String = Nothing
   Public Property EmisorNumero As String = Nothing
   Public Property EmisorTipo As String = Nothing
   Public Property asReceptor As Boolean = Nothing
   Public Property ReceptoNumero As String = Nothing
   Public Property ReceptorTipo As String = Nothing

   Public Property consecutivo As String = Nothing
   Public Property fecha As String = Nothing


   Public Property apiUsuario As String = Nothing
   Public Property apiClave As String = Nothing

   Public Property isSuccess As Boolean = False
   Public Property estado As String = ""

   Public Property respuestaHacienda As String
   Public Property jsonRespuesta As String

   Private TokenHacienda As String

   Private configuracion As confComunicacion

   Public Property response As HttpResponseMessage


   Public Sub New(config As confComunicacion)
      configuracion = config

      certificado = config.llaveRuta
      PIN = config.llavePIN

      apiUsuario = config.apiUsuario
      apiClave = config.apiClave

   End Sub

   ''  ////////////////////////////////////////////////////////////////////////////////////////// Seccion Envia documentos
   Public Sub New(archivoXML As String, config As confComunicacion, pTK As String)
      Try

         TokenHacienda = pTK

         configuracion = config
         archivo = archivoXML

         certificado = config.llaveRuta
         PIN = config.llavePIN

         apiUsuario = config.apiUsuario
         apiClave = config.apiClave

         If Not File.Exists(archivoXML) Then
            Throw New Exception("No existe el archivo de XML")
            Exit Sub

         End If

         Dim xmlEnvia As New Xml.XmlDocument
         xmlEnvia.Load(archivoXML)

         If TypeOf xmlEnvia.FirstChild Is System.Xml.XmlDeclaration Then
            xmlEnvia.RemoveChild(xmlEnvia.FirstChild)
         End If
         xmlEnvia.PreserveWhitespace = False

         '' si es es mensaje receptor
         If xmlEnvia.FirstChild.Name = "MensajeReceptor" Then
            consecutivo = xmlEnvia.GetElementsByTagName("NumConsecutivoReceptor")(0).InnerText
            Clave = xmlEnvia.GetElementsByTagName("Clave")(0).InnerText
            fecha = xmlEnvia.GetElementsByTagName("FechaEmisionDoc")(0).InnerText

            EmisorNumero = xmlEnvia.GetElementsByTagName("NumeroCedulaReceptor")(0).InnerText
            ReceptoNumero = xmlEnvia.GetElementsByTagName("NumConsecutivoReceptor")(0).InnerText
            Exit Sub
         End If

         consecutivo = xmlEnvia.GetElementsByTagName("NumeroConsecutivo")(0).InnerText
         Clave = xmlEnvia.GetElementsByTagName("Clave")(0).InnerText
         EmisorNumero = xmlEnvia.GetElementsByTagName("Emisor")(0)("Identificacion")("Numero").InnerText
         EmisorTipo = xmlEnvia.GetElementsByTagName("Emisor")(0)("Identificacion")("Tipo").InnerText

         If xmlEnvia.GetElementsByTagName("Receptor").Count > 0 Then
            If Not IsNothing(xmlEnvia.GetElementsByTagName("Receptor")(0)("Identificacion")) Then
               asReceptor = True
               ReceptoNumero = xmlEnvia.GetElementsByTagName("Receptor")(0)("Identificacion")("Numero").InnerText
               ReceptorTipo = xmlEnvia.GetElementsByTagName("Receptor")(0)("Identificacion")("Tipo").InnerText
            End If
         Else
            asReceptor = False
         End If

         fecha = xmlEnvia.GetElementsByTagName("FechaEmision")(0).InnerText


      Catch ex As Exception
         Throw New Exception(ex.Message)
      End Try
   End Sub

   Public Function Procesa() As String

      Try

         Dim directorio As String = Path.GetDirectoryName(archivo) & "\"
         Dim nombreArchivo As String = Path.GetFileName(archivo)

         Dim xmlDocSF As New Xml.XmlDocument
         xmlDocSF.Load(directorio & nombreArchivo)

         Dim xmlTextWriter As New Xml.XmlTextWriter(directorio & nombreArchivo, New System.Text.UTF8Encoding(False))
         xmlDocSF.WriteTo(xmlTextWriter)
         xmlTextWriter.Close()
         xmlDocSF = Nothing

         Dim _firma As New Firma
         _firma.FirmaXML_Xades(directorio & nombreArchivo, certificado, False, PIN)

         Dim xmlElectronica As New Xml.XmlDocument
         xmlElectronica.Load(directorio & nombreArchivo)

         'Me.txtXMLFirmado.Text = xmlElectronica.OuterXml

         Dim myEmisor As New Emisor With {.numeroIdentificacion = EmisorNumero,
                                            .TipoIdentificacion = EmisorTipo}

         Dim myReceptor As New Receptor
         If asReceptor Then
            myReceptor = New Receptor With {.numeroIdentificacion = ReceptoNumero,
                                               .TipoIdentificacion = ReceptorTipo}
         Else
            myReceptor.sinReceptor = True
         End If

         Dim myRecepcion As New Recepcion
         myRecepcion.emisor = myEmisor
         myRecepcion.receptor = myReceptor

         myRecepcion.clave = Clave
         myRecepcion.fecha = fecha
         ''Now.ToString("yyyy-MM-ddTHH:mm:sszzz")
         myRecepcion.comprobanteXml = Funciones.EncodeStrToBase64(xmlElectronica.OuterXml)

         xmlElectronica = Nothing

         'Dim Token As String = ""
         'Token = getToken()
         'TokenHacienda = Token

         If TokenHacienda <> "" Then
            Dim enviaFactura As New Comunicacion With {.URL_RECEPCION = configuracion.apiURL}
            enviaFactura.EnvioDatos(TokenHacienda, myRecepcion)    '' ******************    ENVIA
            response = enviaFactura.response

            estado = enviaFactura.estadoFactura
            Select Case enviaFactura.estadoFactura
               Case "recibido"
                  respuestaHacienda += vbCrLf & vbCrLf & enviaFactura.mensajeRespuesta
               Case "procesando"
                  respuestaHacienda = "Consulte en unos minutos, factura se está procesando."
                  respuestaHacienda += vbCrLf & vbCrLf & enviaFactura.mensajeRespuesta
                  respuestaHacienda += vbCrLf & vbCrLf & "Consulte por Clave"
               Case "aceptado"

               Case "rechazado"
                  respuestaHacienda += enviaFactura.xmlRespuesta.GetElementsByTagName("DetalleMensaje").Item(0).InnerText
               Case "error"
            End Select

            Dim jsonEnvio As String = ""
            jsonEnvio = enviaFactura.jsonEnvio

            Dim jsonRespuesta As String = ""
            jsonRespuesta = enviaFactura.jsonRespuesta

            Return enviaFactura.estadoFactura
         Else
            Return ""
         End If

      Catch ex As Exception
         Throw New Exception(ex.Message)
      End Try

   End Function




    Public Function consulta(pclave As String, pTK As String) As String
        Try
            If pclave.Trim.Length = 0 Then
                Throw New Exception("falta la clave de la factura para consultar")
            End If

            If pTK <> "" Then
                Dim enviaFactura As New Comunicacion
                enviaFactura.ConsultaEstatus(pTK, pclave)

                estado = enviaFactura.estadoFactura
                jsonRespuesta = enviaFactura.jsonRespuesta

                Return enviaFactura.mensajeRespuesta
            End If

            Return Nothing
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function


    ''////////////////////////////////////////////////////////////////////////    Seccion de Comprobantes
    ''
    ''

    Public Function comprobante(clave As String, pTK As String) As Comprobante
      TokenHacienda = pTK

      Dim enviaFactura As New Comunicacion With {.URL_RECEPCION = configuracion.apiURL}
      enviaFactura.ComprobanteBusca(TokenHacienda, clave)

      respuestaHacienda = enviaFactura.mensajeRespuesta
      estado = enviaFactura.statusCode
      jsonRespuesta = enviaFactura.jsonRespuesta

      Return enviaFactura.Comprobante
   End Function

   ''' <summary>
   ''' 
   ''' </summary>
   ''' <param name="ini">   A partir de que posición contar los items a retornar 'Example: 10 </param>
   ''' <param name="cant"> A partir de que posición la cantidad de items a retornar  'Example: 15</param>
   ''' <param name="emisor">Cantidad de items a retornar apartir del offset 'Example: 02003101123456</param>
   ''' <param name="receptor"> Tipo y número de identificación del emisor. 'Example: 02003101123456 </param>
   ''' <returns></returns>
   Public Function comprobantesReceptor(ini As Integer, cant As Integer, emisor As String, receptor As String) As List(Of Comprobante)

      If TokenHacienda <> "" Then

         Dim enviaFactura As New Comunicacion With {.URL_RECEPCION = configuracion.apiURL}
         enviaFactura.Comprobantes_Receptor(TokenHacienda, ini, cant, emisor, receptor)

         Return enviaFactura.ComprobanteLista
      Else
         Return Nothing
      End If

   End Function

End Class
