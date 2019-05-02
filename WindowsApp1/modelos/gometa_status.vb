Imports Newtonsoft.Json

Public Class TOKEN

    <JsonProperty("avg_response_time_15min")>
    Public Property AvgResponseTime15min As Object

    <JsonProperty("error_count_15min")>
    Public Property ErrorCount15min As String
End Class

Public Class GETc

    <JsonProperty("avg_response_time_15min")>
    Public Property AvgResponseTime15min As Object

    <JsonProperty("error_count_15min")>
    Public Property ErrorCount15min As String
End Class

Public Class ApiStag

    <JsonProperty("TOKEN")>
    Public Property TOKEN As TOKEN

    <JsonProperty("GET")>
    Public Property GETp As GETc

    <JsonProperty("lasterror_ago")>
    Public Property LasterrorAgo As String

    <JsonProperty("status")>
    Public Property Status As String

    <JsonProperty("lasterror")>
    Public Property Lasterror As String

    <JsonProperty("last_update")>
    Public Property LastUpdate As String
End Class

Public Class ApiProd

    <JsonProperty("last_update")>
    Public Property LastUpdate As String

    <JsonProperty("TOKEN")>
    Public Property TOKEN As TOKEN

    <JsonProperty("status")>
    Public Property Status As String

    <JsonProperty("GET")>
    Public Property GETp As GETc

    <JsonProperty("lasterror_ago")>
    Public Property LasterrorAgo As String

    <JsonProperty("lasterror")>
    Public Property Lasterror As String
End Class

Public Class gometa_status

    <JsonProperty("powered_by")>
    Public Property PoweredBy As String

    <JsonProperty("license")>
    Public Property License As String

    <JsonProperty("api-stag")>
    Public Property ApiStag As ApiStag

    <JsonProperty("api-prod")>
    Public Property ApiProd As ApiProd
End Class

