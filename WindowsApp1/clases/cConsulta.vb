Imports CR.FacturaElectronica
Imports CR.FacturaElectronica.Entidades
Imports CR.FacturaElectronica.Interfaces
Imports CR.FacturaElectronica.Generadores.Detalles
Imports EG.CajaHerramientas
Imports System.IO
Imports CR.FacturaElectronica.Procesos
Imports System.Xml


Public Class cConsulta

    Dim txtAPIUsuario As String = "cpf-05-0269-0349@stag.comprobanteselectronicos.go.cr"
    Dim txtAPIClave As String = "E>++}6U6W:;rE?gvF;-("

    Function consultar(pllave As String) As GetRespuestaConsultaHacienda

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


        Dim consultor As ConsultorDocumentosEnHacienda = New ConsultorDocumentosEnHacienda(config)

        Dim llaves As List(Of String) = New List(Of String)
        llaves.Add(pllave)
        Dim resultado = consultor.EjecutarProceso(llaves)

        Return resultado(0)

    End Function

End Class
