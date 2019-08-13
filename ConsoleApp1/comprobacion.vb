Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports CR.FacturaElectronica
Imports CR.FacturaElectronica.Entidades
Imports CR.FacturaElectronica.Generadores.Detalles
Imports CR.FacturaElectronica.Mensaje_Receptor
Imports CR.FacturaElectronica.Shared
Imports EG.CajaHerramientas

Public Class comprobacion

   Private Shared _configuracion As ConfiguracionCreacionDocumentos
    Public Shared conn As New ConexionSQL($"Data Source=servidor-bd;Initial Catalog=eFactura_sandbox;User ID=sa;Password=123;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")


    Public Shared Sub Main()

      _configuracion = obtenerConfiguracion1(1)

      Dim msgReceptor As MensajeReceptor = New MensajeReceptor()
      With msgReceptor
            .Clave = "50606051900300218208000100001010000002698133241671"
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

      GuardarElXMlParaFirmarlo("clave", fXML)

   End Sub


   'Public Shared Function fcObtenerStringXML(ByVal pvoTiquete As MensajeReceptor) As String
   '   Try
   '      Dim vloSerializador As XmlSerializer = New XmlSerializer(GetType(MensajeReceptor))
   '      Dim vloConfiguraciones As XmlWriterSettings = New XmlWriterSettings()
   '      vloConfiguraciones.Encoding = New UnicodeEncoding(False, False)
   '      vloConfiguraciones.Indent = True
   '      vloConfiguraciones.OmitXmlDeclaration = True

   '      Using vloEscritor As StringWriter = New StringWriter()

   '         Using xmlWriter As XmlWriter = XmlWriter.Create(vloEscritor, vloConfiguraciones)
   '            vloSerializador.Serialize(xmlWriter, pvoTiquete)
   '         End Using

   '         Return vloEscritor.ToString()
   '      End Using

   '   Catch ex As Exception
   '      Throw ex
   '   End Try
   'End Function

   Private Shared Function GuardarElXMlParaFirmarlo(ByVal clave As String, ByVal xml As String) As String
      Dim ruta = _configuracion.RutaXMLRespaldos
      If String.IsNullOrEmpty(ruta) Then ruta = String.Format("{0}\XMLS", Environment.CurrentDirectory)
      If Not Directory.Exists(ruta) Then Directory.CreateDirectory(ruta)
      ruta = String.Format("{0}\{1}.xml", ruta, clave)
      File.WriteAllText(ruta, xml)
      Return ruta
   End Function


   Private Shared Function GenerarConsecutivo(ByVal sucursal As Integer, ByVal terminal As Integer, ByVal consecutivo As Long, ByVal tipoDocumento As EnumeradoresFEL.enmTipoDocumento) As String
      Return String.Format("{0}{1}{2}{3}", sucursal.ToString().PadLeft(3, "0"c), terminal.ToString().PadLeft(5, "0"c), (CInt(tipoDocumento)).ToString().PadLeft(2, "0"c), consecutivo.ToString().PadLeft(10, "0"c))
   End Function

   Private Shared Function GenerarClave(ByVal consecutivo As String, ByVal fechaTransaccion As DateTime, ByVal codigoSeguridad As String, ByVal esUnReproceso As Boolean) As String
      Dim dia = fechaTransaccion.Day.ToString().PadLeft(2, "0"c)
      Dim mes = fechaTransaccion.Month.ToString().PadLeft(2, "0"c)
      Dim anno = fechaTransaccion.Year.ToString().Substring(2, 2)
      Dim cedulaEmisor = _configuracion.EmisorInformacion.Identificacion.Numero.PadLeft(12, "0"c)
      Dim docSituacion = If(esUnReproceso, EnumeradoresFEL.enmSituacionComprobante.Contingencia, If(_configuracion.HayInternet, EnumeradoresFEL.enmSituacionComprobante.Normal, EnumeradoresFEL.enmSituacionComprobante.Sin_Internet))
      Return Constantes.PAIS_CODIGO + dia + mes + anno + cedulaEmisor & consecutivo + CInt(docSituacion) & codigoSeguridad
   End Function

   Private Shared Function obtenerConfiguracion1(pEmisor As Integer) As ConfiguracionCreacionDocumentos
      Try
            Dim sql As String = $"select * from [conf.Emisores] where idPersona = {pEmisor.ToString} "
            Dim configdb = conn.llenaTabla(sql).Rows(0)
         Dim idEmisor As Integer = configdb.Item("idPersona")


         Dim sql1 As String = "select * from [tabla.personas] where id = " & CStr(idEmisor)
         Dim emisorDB = conn.llenaTabla(sql1).Rows(0)


         If Not File.Exists(configdb.Item("rutaLLave")) Then
            Throw New System.Exception("Archivo de Llave criptografica no existe.")
         End If

         Dim c As ConfiguracionCreacionDocumentos = New ConfiguracionCreacionDocumentos()
         With c
            .AlmacenarXMLsEnRutaRespaldos = True
            .HayInternet = True
            .LlaveCriptograficaClave = configdb.Item("pinLLave")
            .LlaveCriptograficaRuta = configdb.Item("rutaLLave")
            .RutaXMLRespaldos = My.Settings.rutaArchivos
            .PoliticaDigest = "Nzk0MTgxMmYxYTNiNDlhYWIxNjkxZjgyMTk0ZTQzMGEzNTFjZTc1ZTA2M2EyMzk0ZjUyZDEyOWIyZTU2ZWM3MQ=="
            .Politica = "https://tribunet.hacienda.go.cr/docs/esquemas/2016/v4.2/ResolucionComprobantesElectronicosDGT-R-48-2016_4.2.pdf"

            .EmisorInformacion = New Generadores.Detalles.Emisor() With {
                    .Identificacion = New Generadores.Detalles.Identificacion() With {
                           .Tipo = emisorDB.Item("tipoID") - 1,
                            .Numero = emisorDB.Item("numeroID")
                        },
                    .CorreoElectronico = emisorDB.Item("correo"),
                    .Nombre = emisorDB.Item("nombre"),
                    .NombreComercial = IIf(IsDBNull(configdb.Item("NombreComercial")), Nothing, configdb.Item("NombreComercial")),
                    .Ubicacion = New Ubicacion With {
                        .Provincia = emisorDB.Item("provincia"),
                        .Canton = emisorDB.Item("canton"),
                        .Distrito = emisorDB.Item("distrito"),
                        .OtrasSenas = emisorDB.Item("otraSenas")
                    },
                    .Telefono = New Telefono() With {
                        .CodigoPais = emisorDB.Item("codigoArea"),
                        .NumTelefono = emisorDB.Item("telefono")
                    }
                 }
         End With
         Return c
      Catch ex As Exception
         Throw New System.Exception(ex.Message)
         Return Nothing
      End Try

   End Function



End Class





