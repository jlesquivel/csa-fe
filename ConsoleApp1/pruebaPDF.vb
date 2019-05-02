Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports
Imports System.Drawing

Module Module2



    Sub Main()

        'Dim clave = "prueba"

        'Dim uri2 As String = $"https://docs.google.com/viewerng/viewer?url=https://csalib.org/facturas/{clave}.pdf"
        'Dim generator As Uri = New Uri(uri2)

        'Dim payload As String = generator.ToString()

        'Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
        'Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q)
        'Dim qrCode As QRCode = New QRCode(qrCodeData)

        'Dim imagenQR = qrCode.GetGraphic(20)

        'imagenQR.Save("d:\qr20.png")

        Try


            Dim factloca = 39
            Dim factSvr = 36

            Dim ruta = My.Computer.FileSystem.SpecialDirectories.Desktop
            Dim clave = "prueba"
            Dim idFact = 20

            '***********

            Dim reporte As String = CurDir() & "\eFactura.rpt"
            Dim orpt = New ReportDocument()
            orpt.Load(reporte)


            Dim formatType As ExportFormatType = ExportFormatType.PortableDocFormat
            Dim separador = IIf(ruta.Last() = "\", "", "\")
            Dim nombrePDF As String = ruta & separador & clave & ".pdf"

            If System.IO.File.Exists(nombrePDF) = True Then
                System.IO.File.Delete(nombrePDF)
            End If


            orpt.SetParameterValue("@idFactura", idFact)

            Dim username = "sa"
            Dim password = "123"
            orpt.SetDatabaseLogon(username, password)

            RecurseAndRemap(orpt)

            orpt.ExportToDisk(formatType, nombrePDF)

        Catch engEx As LogOnException
            Throw New Exception _
            ("Incorrect Logon Parameters. Check your user name and password.")
        Catch engEx As DataSourceException
            Throw New Exception _
               ("An error has occurred while connecting to the database.")
        Catch engEx As EngineException
            Throw New Exception(engEx.Message)
        End Try

    End Sub



    Private Sub RecurseAndRemap(ByRef CR As Engine.ReportDocument)

        Dim local = "(localdb)\MSSQLLocalDB"
        Dim srvDB = "servidor-bd"
        Dim usuario = ""
        Dim clave = ""

        Dim Servidor = srvDB
        Dim segIntegrada As Boolean = False

        If segIntegrada = False Then
            usuario = "sa"
            clave = "123"
        End If

        For Each DSC As CrystalDecisions.Shared.IConnectionInfo In CR.DataSourceConnections
            DSC.SetLogon(usuario, clave)
            DSC.SetConnection(Servidor, "eFactura", segIntegrada)
        Next

        CR.SetDatabaseLogon(usuario, clave)

        For Each Table As Engine.Table In CR.Database.Tables
            Table.LogOnInfo.ConnectionInfo.ServerName = Servidor
            Table.LogOnInfo.ConnectionInfo.IntegratedSecurity = segIntegrada
            Table.LogOnInfo.ConnectionInfo.UserID = usuario
            Table.LogOnInfo.ConnectionInfo.Password = clave
        Next

        If Not CR.IsSubreport Then
            For Each SR As Engine.ReportDocument In CR.Subreports
                RecurseAndRemap(SR)
            Next
        End If
    End Sub


End Module


'Private Sub ProcessFile(ByVal FileName As String)
'   Dim CR As Engine.ReportDocument = Nothing
'   Try
'      CR = New Engine.ReportDocument
'      CR.Load(FileName, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)

'      'Recurse thru Report
'      RecurseAndRemap(CR)
'      'Save File
'      CR.SaveAs("OutPutFilePath")

'   Catch ex As Exception
'      MessageBox.Show(ex.Message)
'   Finally
'      If Not CR Is Nothing Then
'         CR.Close()
'         CR.Dispose()
'      End If
'   End Try
'End Sub

'Private Sub RecurseAndRemap(ByVal CR As Engine.ReportDocument)
'   For Each DSC As CrystalDecisions.Shared.IConnectionInfo In CR.DataSourceConnections
'      DSC.SetLogon("YourUserName", "YourPassword")
'      DSC.SetConnection("YouServerName", "YourDatabaseName", False)
'   Next

'   CR.SetDatabaseLogon("YourUserName", "YourPassword")

'   For Each Table As Engine.Table In CR.Database.Tables
'      Table.LogOnInfo.ConnectionInfo.UserID = "YourUserName"
'      Table.LogOnInfo.ConnectionInfo.Password = "YourPassword"
'   Next

'   If Not CR.IsSubreport Then
'      For Each SR As Engine.ReportDocument In CR.Subreports
'         RecurseAndRemap(SR)
'      Next
'   End If
'End Sub