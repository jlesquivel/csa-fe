Imports System.Net.Mail
Imports System.IO
Imports System.Net.Mime
Imports EG.EnviaFactura


Public Class cCorreo

    Public Property statusEnvio As String
    Public Property cnf As DataRow

    ''TODO eliminar este variable cuando este en produccion
    Public para As String = "csalib.web@gmail.com"

    Dim conn As New ConexionSQL(My.Settings.eFacturaConnection)


    ''' <summary>
    ''' 
    ''' </summary>
    Sub enviar(idFact As Integer, ruta As String, clave As String, cConf As confComunicacion)

        Dim mail As New MailMessage()
        mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure Or DeliveryNotificationOptions.OnSuccess

        Dim verificaMail As New EG.CajaHerramientas.email
        Dim creadoMail = False

        Try

            If cConf.apiUsuario.Contains("@prod.") Then
                ' en produccion activar el correo del cliente
                para = getMailReceptor(idFact)
            End If

            If para IsNot Nothing Then

                creadoMail = True

                mail = New MailMessage()
                mail.From = New MailAddress(cnf.Item("emailSend"), cnf.Item("emailNombre"))
                mail.To.Add(para)
                mail.Bcc.Add("facturacion@csalib.org")
                mail.Subject = "Colegio Santa Ana - Factura"
                mail.Body = cnf.Item("emailBody")


                ruta = ruta & IIf(ruta.EndsWith("\"), "", "\")
                Dim archPDF As String = ruta & clave & ".pdf"
                Dim archXML As String = ruta & clave & ".xml"

                If File.Exists(archPDF) Then
                    Dim Data As Attachment = New Attachment(archPDF, MediaTypeNames.Application.Octet)
                    mail.Attachments.Add(Data)
                End If

                If File.Exists(archXML) Then
                    Dim Data As Attachment = New Attachment(archXML, MediaTypeNames.Application.Octet)
                    mail.Attachments.Add(Data)
                End If
            Else
                creadoMail = False
                mail = Nothing
            End If
        Catch ex As Exception
            Throw (New Exception(ex.Message & " >>> " & ex.StackTrace.ToString))
        End Try

        Dim SmtpServer As New SmtpClient(cnf.Item("emailHost"), cnf.Item("emailPort"))

        Dim servUsuario As String = cnf.Item("emailSend")
        Dim servClave As String = cnf.Item("emailSendPass")

        SmtpServer.Credentials = New Net.NetworkCredential(servUsuario, servClave)

        Try
            If creadoMail Then  ' si tiene destinatario
                SmtpServer.Send(mail)
                statusEnvio = "Envio existoso"
            End If

        Catch Emailex As SmtpFailedRecipientsException
            statusEnvio = "Error :" & Emailex.Message
            Throw (New Exception(Emailex.Message & " >>> " & Emailex.StackTrace.ToString))
        End Try


    End Sub

    Function getMailReceptor(idFact As Integer) As String

        Dim correo As String = Nothing

        Dim res = conn.llenaTabla("EXEC [receptor_idFactura]" & idFact.ToString)
        If res.Rows.Count > 0 Then
            correo = res(0).Item("correo")

            Dim correoEG As New EG.CajaHerramientas.email
            If Not correoEG.IsValidEmail(correo) Then
                correo = Nothing
            End If
        End If


        Return correo
    End Function

End Class


'Dirección de webmail	https: //webmail.hostinger.mx
'Host POP3	pop.hostinger.mx
'Puerto POP3(seguro)	995 
'
'Host IMAP	imap.hostinger.mx
'Puerto IMAP(seguro)	993 
'
'Host SMTP	smtp.hostinger.mx
'Puertos SMTP(seguro)	587 
'Registro MX	mx1.hostinger.mx