﻿Imports System.Net.Http

Public Class TokenHacienda

    Public Property accessToken As String
    Public Property refreshToken As String
    Public Property isCorrecto As Boolean

    Public Sub GetTokenHacienda(usuario As String, password As String)
        Try
            accessToken = ""
            refreshToken = ""
            isCorrecto = False

            Dim IDP_CLIENT_ID = "api-stag"
            Dim IDP_URI = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token"

            If usuario.Contains("prod") Then
                IDP_CLIENT_ID = "api-prod"
                IDP_URI = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut/protocol/openid-connect/token"
            End If


            Dim http As HttpClient = New HttpClient
            Dim param = New List(Of KeyValuePair(Of String, String))()
            param.Add(New KeyValuePair(Of String, String)("client_id", IDP_CLIENT_ID))
            param.Add(New KeyValuePair(Of String, String)("grant_type", "password"))
            param.Add(New KeyValuePair(Of String, String)("username", usuario))
            param.Add(New KeyValuePair(Of String, String)("password", password))
            Dim content As FormUrlEncodedContent = New FormUrlEncodedContent(param)

            Dim response As HttpResponseMessage = http.PostAsync(IDP_URI, content).Result
            Dim res As String = response.Content.ReadAsStringAsync.Result
            Dim tk As Token = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(res)
            If response.StatusCode = Net.HttpStatusCode.OK Then
                isCorrecto = True
                accessToken = tk.access_token
                refreshToken = tk.refresh_token
            End If
        Catch e As Exception

            Throw New Exception(e.InnerException.Message)
        End Try
    End Sub

End Class
