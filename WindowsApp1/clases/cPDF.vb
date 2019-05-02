Imports System.Data.SqlClient
Imports System.Data
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class cPDF

    Public clave As String

    Dim StrConn As String = My.Settings.eFacturaConnection
    Dim conn As New ConexionSQL(StrConn)

    Public imagenQR As Bitmap


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Function GenerarQR() As Bitmap

        Dim uri2 As String = $"https://docs.google.com/viewerng/viewer?url=https://csalib.org/facturas/{clave}.pdf"
        Dim generator As Uri = New Uri(uri2)

        Dim payload As String = generator.ToString()

        Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q)
        Dim qrCode As QRCode = New QRCode(qrCodeData)

        imagenQR = qrCode.GetGraphic(12)
        Return imagenQR

    End Function

    Sub salvarQR(idFact As Integer)

        Dim tempMemStream As New IO.MemoryStream
        If imagenQR Is Nothing Then
            GenerarQR()
        End If

        imagenQR.Save(tempMemStream, Imaging.ImageFormat.Jpeg)
        Dim imageData = tempMemStream.ToArray()

        Try
            Dim cnn = conn.conexion
            If cnn.State = ConnectionState.Closed Then
                cnn.Open()
            End If

            Dim cmd = New SqlCommand("guardaQR", cnn)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@idFact", idFact)
            cmd.Parameters.AddWithValue("@imagen", imageData)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub GenerarPDf(ruta As String, clave As String, idFact As String, idClient As String)
        Try
            Dim reporte As String = Application.StartupPath() & "\eFactura.rpt"
            Dim rpt = New ReportDocument()
            rpt.Load(reporte)

            Dim formatType As ExportFormatType = ExportFormatType.PortableDocFormat
            Dim separador = IIf(ruta.Last() = "\", "", "\")
            Dim nombrePDF As String = ruta & separador & clave & ".pdf"

            If System.IO.File.Exists(nombrePDF) = True Then
                System.IO.File.Delete(nombrePDF)
            End If

            Dim username = "colegiosa"
            Dim password = "C$@123"

            Asigna_servidor(rpt)
            rpt.SetDatabaseLogon(username, password)


            '? parametros del reporte
            rpt.SetParameterValue("@idFactura", idFact)
            rpt.SetParameterValue("@idCliente", idClient)

            rpt.ExportToDisk(formatType, nombrePDF)
            rpt.Close()
            rpt.Dispose()

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


    Sub Asigna_servidor(ByRef rpt)

        Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
        Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo

        For Each tbCurrent In rpt.Database.Tables
            tliCurrent = tbCurrent.LogOnInfo

            With tliCurrent.ConnectionInfo
                .ServerName = conn.Servidor
                .UserID = conn.vusuario
                .Password = conn.vpassword
                .DatabaseName = conn.Bd
                If conn.vusuario <> "" Then
                    .IntegratedSecurity = False
                End If

            End With
            tbCurrent.ApplyLogOnInfo(tliCurrent)
        Next tbCurrent

    End Sub


End Class



