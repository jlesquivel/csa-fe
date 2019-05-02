
Imports CR.FacturaElectronica.Entidades
Imports CR.FacturaElectronica.Procesos
Imports System
Imports System.Collections.Generic
Imports CR.FacturaElectronica.Interfaces
Imports CR.FacturaElectronica.Generadores.Detalles
Imports EG.CajaHerramientas
Imports System.IO
Imports System.Threading.Tasks

Imports System.Xml

Public Class cDespachador

    Dim txtAPIUsuario As String = "cpf-05-0269-0349@stag.comprobanteselectronicos.go.cr"
    Dim txtAPIClave As String = "E>++}6U6W:;rE?gvF;-("

    Dim txtXML As String
    Dim txtConsecutivo As String
    Dim txtClave As String
    Dim txtEmisorNumero As String
    Dim txtEmisorTipo As String

    Dim txtReceptorNumero As String
    Dim txtReceptorTipo As String

    Dim txtFecha As String

    Function Enviar(pArchivoXML As String) As PostRespuestaEnvioHacienda
        Dim config As ConfiguracionComunicacionHacienda = New ConfiguracionComunicacionHacienda()
        With config
            .ClientID = "api-stag"
            .ClientSecret = ""
            .GrantType = "password"
            .TipoAutenticacion = "bearer"
            .UrlApiHacienda = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/recepcion"
            .UrlIdpLogIn = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token"
            .UrlIdpLogOut = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/logout"
            .IdpUsuario = txtAPIUsuario
            .IdpContrasenna = txtAPIClave
        End With

        obtieneDatos(pArchivoXML)
        Dim despechador = New DespachadorDocumentosAHacienda(config)

        Dim listadocs = New List(Of DocumentoDto)
        Dim doc As DocumentoDto = New DocumentoDto() With {
            .clave = txtClave, ' la clave de 50 caracteres
            .comprobanteXml = txtXML, ' el comprobante en formato XML
            .emisor = New PersonaDocumentoDto() With { ' la informacion del emisor
                     .numeroIdentificacion = txtEmisorNumero,
                      .tipoIdentificacion = txtEmisorTipo
                      },
            .receptor = IIf(Not IsNothing(txtReceptorNumero),
                       New PersonaDocumentoDto() With { ' la informacion del emisor
                              .numeroIdentificacion = txtReceptorNumero,
                              .tipoIdentificacion = txtReceptorTipo
                      }, Nothing),
              .fecha = txtFecha 'la fecha de la factura-> cuando la factura se hizo
              }

        listadocs.Add(doc)   '' agregar documento

        Dim resp As List(Of PostRespuestaEnvioHacienda)
        resp = despechador.EjecutarProceso(listadocs)

        Return resp(0)
    End Function


    Public Sub obtieneDatos(pArchivo As String)
        Dim doc As New XmlDocument
        doc.Load(pArchivo)

        Dim xmlEnvia As New Xml.XmlDocument
        xmlEnvia.LoadXml(doc.InnerXml)
        txtXML = doc.InnerXml

        If TypeOf xmlEnvia.FirstChild Is System.Xml.XmlDeclaration Then
            xmlEnvia.RemoveChild(xmlEnvia.FirstChild)
        End If
        xmlEnvia.PreserveWhitespace = False

        If xmlEnvia.FirstChild.Name = "MensajeReceptor" Then
            CargaDatosXMLMensajeReceptor(xmlEnvia)
            Exit Sub
        End If

        txtConsecutivo = xmlEnvia.GetElementsByTagName("NumeroConsecutivo")(0).InnerText
        txtClave = xmlEnvia.GetElementsByTagName("Clave")(0).InnerText
        txtEmisorNumero = xmlEnvia.GetElementsByTagName("Emisor")(0)("Identificacion")("Numero").InnerText
        txtEmisorTipo = xmlEnvia.GetElementsByTagName("Emisor")(0)("Identificacion")("Tipo").InnerText

        If xmlEnvia.GetElementsByTagName("Receptor").Count > 0 Then
            If Not IsNothing(xmlEnvia.GetElementsByTagName("Receptor")(0)("Identificacion")) Then
                txtReceptorNumero = xmlEnvia.GetElementsByTagName("Receptor")(0)("Identificacion")("Numero").InnerText
                txtReceptorTipo = xmlEnvia.GetElementsByTagName("Receptor")(0)("Identificacion")("Tipo").InnerText
            End If
        End If

        txtFecha = xmlEnvia.GetElementsByTagName("FechaEmision")(0).InnerText

    End Sub

    Private Sub CargaDatosXMLMensajeReceptor(xmlEnvia As Xml.XmlDocument)
        Try
            txtConsecutivo = xmlEnvia.GetElementsByTagName("NumConsecutivoReceptor")(0).InnerText
            txtClave = xmlEnvia.GetElementsByTagName("Clave")(0).InnerText
            txtFecha = xmlEnvia.GetElementsByTagName("FechaEmisionDoc")(0).InnerText

            txtEmisorNumero = xmlEnvia.GetElementsByTagName("NumeroCedulaReceptor")(0).InnerText
            txtReceptorNumero = xmlEnvia.GetElementsByTagName("NumConsecutivoReceptor")(0).InnerText

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Sub limpia()
        txtXML = Nothing
        txtConsecutivo = Nothing
        txtClave = Nothing
        txtEmisorNumero = Nothing
        txtEmisorTipo = Nothing

        txtReceptorNumero = Nothing
        txtReceptorTipo = Nothing

        txtFecha = Nothing
    End Sub


End Class


'<?xml version="1.0" encoding="utf-8"?>  
'<Form_Layout>
'<Location>
'<LocX>100</LocX>
'    <LocY>100</LocY>  
'  </Location>  
'  <Size>
'<Width>300</Width>  
'    <Height>300</Height>  
'  </Size>  
'</Form_Layout> 