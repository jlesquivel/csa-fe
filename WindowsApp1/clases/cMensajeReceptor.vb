Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Imports CR.FacturaElectronica
Imports CR.FacturaElectronica.Entidades
Imports CR.FacturaElectronica.Interfaces
Imports CR.FacturaElectronica.Generadores.Detalles
Imports CR.FacturaElectronica.Mensaje_Receptor
Imports CR.FacturaElectronica.Shared


Public Class CMensajeReceptor

    Private oFactura As New cFactura
    Private _configuracion As ConfiguracionCreacionDocumentos
    Public creador As ICreadorDocumentos


    Public Sub New(pcnf As DataRow)

        oFactura.rutaArchivos = pcnf.Item("rutaArch")
        oFactura.emisorDB = pcnf
        _configuracion = oFactura.ObtenerConfiguracion1()
    End Sub

    Public Function GenerarXML(idMensaje As Integer) As RespuestaCreacionDoc

        Dim retorna As RespuestaCreacionDoc = Nothing
        creador = New CreadorDocumentos(_configuracion)
        If creador IsNot Nothing Then
            retorna = CreadorMR(idMensaje)
        End If
        Return retorna
    End Function


    Private Function CreadorMR(idMensaje) As RespuestaCreacionDoc

        Dim respuesta = New RespuestaCreacionDoc()
        Dim rutaGuardado As String = ""

        Dim _tipoDoc As EnumeradoresFEL.enmTipoDocumento = Nothing
        Dim _consecBD As Long = Nothing

        Dim _consecutivo = GenerarConsecutivo(1, 1, _consecBD, _tipoDoc)
        Dim _clave = Me.GenerarClave(_consecutivo, DateTime.Now, GeneraTokenSeguridad(8), False)

        '? Corregir los datos del receptor

        Try
            Dim msgReceptor As MensajeReceptor = New MensajeReceptor()
            With msgReceptor
                .Clave = _clave
                .NumeroCedulaEmisor = "003002182080"
                .NumeroCedulaReceptor = "000502690349"
                .FechaEmisionDoc = Now
                .Mensaje = 1
                .DetalleMensaje = "aceptado"
                .MontoTotalImpuestoSpecified = True
                .MontoTotalImpuesto = 0
                .TotalFactura = 0
                .NumeroConsecutivoReceptor = "00100001010000002698"
            End With

            Dim oGenera = New Mensaje_Receptor.MensajeReceptorProcesador
            Dim fXML As String = oGenera.fcObtenerStringXML(msgReceptor)

            rutaGuardado = GuardarElXMlParaFirmarlo(_clave, fXML)

            '? REPUESTA CORRECTA 
            respuesta.ConsecutivoDocCreado = _consecutivo
            respuesta.ClaveDocCreada = _clave
            respuesta.EstadoDocumento = RespuestaCreacionDoc.enmEstadoDocumento.CreadoCorrectamente
            respuesta.NuevoConsecutivoSistema = _consecutivo + 1

            respuesta.archivo = rutaGuardado
            respuesta.FechaEmision = msgReceptor.FechaEmisionDoc

        Catch ex As Exception
            '? REPUESTA INCORRECTA ####
            respuesta.ErrorMensaje = ex.Message
            respuesta.EstadoDocumento = RespuestaCreacionDoc.enmEstadoDocumento.NoCreado
            respuesta.NuevoConsecutivoSistema = _consecutivo
            File.Delete(rutaGuardado)
        End Try

        Return respuesta
    End Function


    Private Function GuardarElXMlParaFirmarlo(ByVal clave As String, ByVal xml As String) As String
        Dim ruta = _configuracion.RutaXMLRespaldos

        If String.IsNullOrEmpty(ruta) Then
            ruta = String.Format("{0}\XMLS", Environment.CurrentDirectory)
        End If
        If Not Directory.Exists(ruta) Then
            Directory.CreateDirectory(ruta)
        End If

        ruta = String.Format("{0}\{1}.xml", ruta, clave)
        File.WriteAllText(ruta, xml)
        Return ruta
    End Function

    Private Function GenerarConsecutivo(ByVal sucursal As Integer, ByVal terminal As Integer, ByVal consecutivo As Long, ByVal tipoDocumento As EnumeradoresFEL.enmTipoDocumento) As String
        Return String.Format("{0}{1}{2}{3}", sucursal.ToString().PadLeft(3, "0"c), terminal.ToString().PadLeft(5, "0"c), (CInt(tipoDocumento)).ToString().PadLeft(2, "0"c), consecutivo.ToString().PadLeft(10, "0"c))
    End Function
    Private Function GenerarClave(ByVal consecutivo As String, ByVal fechaTransaccion As DateTime, ByVal codigoSeguridad As String, ByVal esUnReproceso As Boolean) As String
        Dim dia = fechaTransaccion.Day.ToString().PadLeft(2, "0"c)
        Dim mes = fechaTransaccion.Month.ToString().PadLeft(2, "0"c)
        Dim anno = fechaTransaccion.Year.ToString().Substring(2, 2)
        Dim cedulaEmisor = _configuracion.EmisorInformacion.Identificacion.Numero.PadLeft(12, "0"c)
        Dim docSituacion = If(esUnReproceso, EnumeradoresFEL.enmSituacionComprobante.Contingencia, If(_configuracion.HayInternet, EnumeradoresFEL.enmSituacionComprobante.Normal, EnumeradoresFEL.enmSituacionComprobante.Sin_Internet))
        Return Constantes.PAIS_CODIGO & dia & mes & anno & cedulaEmisor & consecutivo & docSituacion & codigoSeguridad

    End Function

    Private Function GeneraTokenSeguridad(ByVal pvcTamaño As Integer) As String
        Dim vlocharSet As String
        Dim vloCarArray As Char()
        Dim vloDato As Byte()
        Dim vloObjCripto As RNGCryptoServiceProvider
        Dim vloResultado As StringBuilder

        Try
            vlocharSet = "0123456789"
            vloCarArray = vlocharSet.ToCharArray()
            vloDato = New Byte(0) {}
            vloObjCripto = New RNGCryptoServiceProvider()
            vloObjCripto.GetNonZeroBytes(vloDato)
            vloDato = New Byte(pvcTamaño - 1) {}
            vloObjCripto.GetNonZeroBytes(vloDato)
            vloResultado = New StringBuilder(pvcTamaño)

            For Each vloByte As Byte In vloDato
                vloResultado.Append(vloCarArray(vloByte Mod (vloCarArray.Length)))
            Next

            Return vloResultado.ToString()
        Catch __unusedException1__ As Exception
            Return "12345678"
        End Try
    End Function

End Class
