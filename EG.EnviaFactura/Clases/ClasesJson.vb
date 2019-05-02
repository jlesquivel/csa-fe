Imports Newtonsoft.Json
Imports System

Public Class ClasesJson
End Class

Public Class RespuestaHacienda
    <JsonProperty("clave")>
    Public Property clave As String

    <JsonProperty("fecha")>
    Public Property fecha As String

    <JsonProperty("ind-estado")>
    Public Property ind_estado As String

    <JsonProperty("respuesta-xml")>
    Public Property respuesta_xml As String
End Class

Public Class Token
    <JsonProperty("access_token")>
    Public Property access_token As String

    <JsonProperty("refresh_token")>
    Public Property refresh_token As String
End Class

Public Class Recepcion
    <JsonProperty("clave")>
    Public Property clave As String

    <JsonProperty("fecha")>
    Public Property fecha As String

    <JsonProperty("emisor")>
    Public Property emisor As Emisor

    <JsonProperty("receptor")>
    Public Property receptor As Receptor

    <JsonProperty("comprobanteXml")>
    Public Property comprobanteXml As String
End Class

Public Class Emisor
    <JsonProperty("TipoIdentificacion")>
    Public Property TipoIdentificacion As String
    <JsonProperty("numeroIdentificacion")>
    Public Property numeroIdentificacion As String
End Class

Public Class Receptor
    <JsonProperty("TipoIdentificacion")>
    Public Property TipoIdentificacion As String
    <JsonProperty("numeroIdentificacion")>
    Public Property numeroIdentificacion As String
    Public Property sinReceptor As Boolean = False
End Class


''******************** COMPROBANTES


Public Class Comprobante
    <JsonProperty("clave")>
    Public Property clave As String

    <JsonProperty("fecha")>
    Public Property fecha As String

    <JsonProperty("emisor")>
    Public Property emisor As EmisorComprobante

    <JsonProperty("receptor")>
    Public Property receptor As ReceptorComprobante

    <JsonProperty("notasCredito")>
    Public Property notasCredito As List(Of NotasCredito)

    <JsonProperty("notasDebito")>
    Public Property notasDebito As List(Of NotasDebito)

End Class

Public Class EmisorComprobante
    <JsonProperty("TipoIdentificacion")>
    Public Property TipoIdentificacion As String
    <JsonProperty("numeroIdentificacion")>
    Public Property numeroIdentificacion As String
End Class

Public Class ReceptorComprobante
    <JsonProperty("TipoIdentificacion")>
    Public Property TipoIdentificacion As String
    <JsonProperty("numeroIdentificacion")>
    Public Property numeroIdentificacion As String
    Public Property sinReceptor As Boolean = False
End Class


Public Class NotasCredito
    <JsonProperty("clave")>
    Public Property TipoIdentificacion As String
    <JsonProperty("fecha")>
    Public Property numeroIdentificacion As String
End Class

Public Class NotasDebito
    <JsonProperty("clave")>
    Public Property TipoIdentificacion As String
    <JsonProperty("fecha")>
    Public Property numeroIdentificacion As String
End Class