
Imports CR.FacturaElectronica
Imports CR.FacturaElectronica.Entidades
Imports CR.FacturaElectronica.Interfaces
Imports CR.FacturaElectronica.Generadores.Detalles
Imports EG.CajaHerramientas
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Globalization

Public Class cFactura

    Private FIRMAR = False
    Public productos As New List(Of LineaDetalle)
    Public rutaArchivos As String
    Public conn As New ConexionSQL(My.Settings.eFacturaConnection)
    Public creador As ICreadorDocumentos

    Public Function GenerarXML(idFact As Integer) As RespuestaCreacionDoc

        Dim retorna As RespuestaCreacionDoc = Nothing
        creador = New CreadorDocumentos(obtenerConfiguracion1(1))
        If creador IsNot Nothing Then
            retorna = creador.CrearDocumentoXML(obtenerDocumento1(idFact), FIRMAR)
        End If

        Return retorna

    End Function

   Private Function obtenerConfiguracion1(pEmisor As Integer) As ConfiguracionCreacionDocumentos
      Try
         Dim sql As String = "select * from [conf.Emisores] where idPersona = " & pEmisor.ToString
         Dim configdb = conn.llenaTabla(sql).Rows(0)
         Dim idEmisor As Integer = configdb.Item("idPersona")


         Dim sql1 As String = "select * from [tabla.personas] where id = " & CStr(idEmisor)
         Dim emisorDB = conn.llenaTabla(sql1).Rows(0)

         If Not Directory.Exists(rutaArchivos) Then
            Throw New System.Exception("Directorio de respaldo no existe.")
            ' Directory does not exist.
         End If

         If Not File.Exists(configdb.Item("rutaLLave")) Then
            Throw New System.Exception("Archivo de Llave criptografica no existe.")
         End If

         Dim c As ConfiguracionCreacionDocumentos = New ConfiguracionCreacionDocumentos()
         With c
            .AlmacenarXMLsEnRutaRespaldos = True
            .HayInternet = True
            .LlaveCriptograficaClave = configdb.Item("pinLLave")
            .LlaveCriptograficaRuta = configdb.Item("rutaLLave")
            .RutaXMLRespaldos = rutaArchivos
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


   Private Function getImpuestos(idfacturaDetalle) As List(Of ImpuestoSistema)

      Dim sqlFact As String = "select * from [fact.facturaImpuestos] where idFactDetalle = " & idfacturaDetalle.ToString()
      Dim ImpuestosDB = conn.llenaTabla(sqlFact)

      Dim imp As New List(Of ImpuestoSistema)

      For Each impuesto In ImpuestosDB.Rows
         imp.Add(New ImpuestoSistema With {
            .Codigo = impuesto.item("codigo"),
            .Tarifa = impuesto.item("tarifa"),
            .Monto = impuesto.item("monto")
         })
      Next

      Return imp
   End Function

   Private Function exo() As Exoneracion
      Return New Exoneracion()
      '   With {
      '   .TipoDocumento = "99",
      '   .NumeroDocumento = "123243",
      '   .NombreInstitucion = "Liceo experimental",
      '   .FechaEmision = DateTime.Now,
      '   .MontoImpuestoExon = 12,
      '   .MontoTotalLinea = 12,
      '   .PorcentajeCompra = 100
      '}
   End Function

   Private Function DetallesF(idFact As Integer) As List(Of LineaDetalleSistema)
      Dim sqlFact As String = "select * from [fact.facturaDetalle] where idFactura = " & idFact.ToString()
      Dim factDB = conn.llenaTabla(sqlFact)

      Dim lista As New List(Of LineaDetalleSistema)

      For Each registro In factDB.Rows
         lista.Add(New LineaDetalleSistema() With {
                .Codigo = registro.item("codigo"),
                .UnidadMedida = registro.item("unidadMedida"),
                .Detalle = registro.item("detalle"),
                .Cantidad = registro.item("cantidad"),
                .PrecioUnitario = registro.item("precioUnitario"),
                .MontoTotal = registro.item("montoTotal"),
                .MontoDescuento = registro.item("montoDescuento"),
                .MontoTotalLinea = registro.item("montoTotal"),
                .SubTotal = registro.item("subTotal"),
                .Impuesto = getImpuestos(registro.item("Id")),
                .NaturalezaDescuento = ""
        })
      Next

      Return lista
   End Function

   Private Function obtenerDocumento1(idFact As Integer) As DocumentoParametros

      Dim sqlFact As String = "select * from [fact.factura] where id = " & idFact.ToString()
      Dim factDB = conn.llenaTabla(sqlFact).Rows(0)

      Dim sql As String = "select * from [tabla.personas] where id = " & CStr(factDB.Item("enc_emisor"))
      Dim emisorDB = conn.llenaTabla(sql).Rows(0)

      Dim sql1 As String = "select * from [tabla.personas] where id = " & CStr(factDB.Item("enc_receptor"))
      Dim receptorDB As DataRow = Nothing
      Dim receptorTabla = conn.llenaTabla(sql1)
      If receptorTabla.Rows.Count > 0 Then
         receptorDB = receptorTabla.Rows(0)
      End If


      '? valida aqui que la cedula exista y el correo sea valido segun las reglas de hacienda
      ' ?  sino omitir el receptor
      Dim receptorValido As Boolean = False
      If receptorDB IsNot Nothing Then
         Dim sql_receptor As String = $"EXEC [dbo].[buscaSIC] @id_buscar = N'{receptorDB.Item("numeroID")}', @tipo = N'0{receptorDB.Item("tipoID")}'"

         Dim registro As DataRow = Nothing
         Dim buscaSIC = conn.llenaTabla(sql_receptor)
         If buscaSIC.Rows.Count > 0 Then
            receptorValido = True
         End If
      End If


      Dim vReceptor As Generadores.Detalles.Receptor
      If factDB.Item("enc_receptor") = 0 Or (Not receptorValido) Then
         vReceptor = Nothing
      Else
         vReceptor = New Generadores.Detalles.Receptor With {
                    .Identificacion = New Generadores.Detalles.Identificacion() With {
                        .Tipo = receptorDB.Item("tipoID") - 1,
                        .Numero = receptorDB.Item("numeroID")
                    },
                    .Nombre = receptorDB.Item("nombre"),
                        .Ubicacion = New Ubicacion() With {
                        .Provincia = receptorDB.Item("provincia"),
                        .Canton = receptorDB.Item("canton"),
                        .Distrito = receptorDB.Item("distrito"),
                        .OtrasSenas = receptorDB.Item("otraSenas")
                    },
                    .CorreoElectronico = IIf(IsValidEmail(receptorDB.Item("correo")), receptorDB.Item("correo"), Nothing),
                    .Telefono = New Telefono() With {
                        .CodigoPais = receptorDB.Item("codigoArea"),
                        .NumTelefono = receptorDB.Item("telefono")
                    }
                }
      End If

        'TODO corregir el tipo de documento que no solo sea factura
        ' 
        Dim p As New DocumentoParametros() With {
            .ConsecutivoSistema = factDB.Item("consecutivo"),
            .Sucursal = factDB.Item("enc_sucursal"),
            .Terminal = factDB.Item("enc_terminal"),
            .TipoDocumento = getTipodocumento(factDB.Item("documento")),
            .EsUnReproceso = factDB.Item("enc_esReproceso"),
            .Encabezado = New Encabezado() With {
                .CondicionVenta = factDB.Item("enc_condicionVenta"),
                .MediosPago = New String() {factDB.Item("enc_medioPago")},
                .NormativaFecha = factDB.Item("enc_normativaFecha"),
                .NormativaNombre = factDB.Item("enc_normativaNombre"),
                .PlazoCredito = factDB.Item("enc_PlazoCredito"),
                .Receptor = vReceptor
            },
            .LineasDetalle = DetallesF(idFact),
            .Resumen = New ResumenFactura() With {
               .CodigoMoneda = ResumenFactura.Moneda.CRC,
               .TipoCambio = 1,
               .TotalComprobante = factDB.Item("res_totalComprobante"),
               .TotalDescuentos = factDB.Item("res_totalDescuento"),
               .TotalExento = factDB.Item("res_totalExento"),
               .TotalGravado = factDB.Item("res_totalGravado"),
               .TotalImpuesto = factDB.Item("res_totalImpuestos"),
               .TotalMercanciasExentas = factDB.Item("res_totalMercanciaExenta"),
               .TotalMercanciasGravadas = factDB.Item("res_totalMercanciaGravadas"),
               .TotalServExentos = factDB.Item("res_totalServExento"),
               .TotalServGravados = factDB.Item("res_totalServGravados"),
               .TotalVenta = factDB.Item("res_totalVenta"),
               .TotalVentaNeta = factDB.Item("res_totalVentaNeta")
                },
            .DocumentosReferencia = New List(Of DocumentoReferenciaSistema)
            }


        p.DocumentosReferencia = ReferenciasF(idFact)  ' ////////////////////////// REFERENCIAS



        p.SeccionOtros = New Dictionary(Of String, String)

      If Not IsDBNull(factDB.Item("res_observacion")) Then
         p.SeccionOtros.Add("Observaciones", factDB.Item("res_observacion"))
      End If
      p.SeccionOtros.Add("Generador", "-- CSA Comprobante Electrónico --")

      'p.SeccionOtros.Add("llave 3", "valor 3")
      'p.SeccionOtros.Add("llave 4", "valor 4")

      Return p
   End Function

    Private Function ReferenciasF(idFact As Integer) As List(Of DocumentoReferenciaSistema)

        Dim sqlFact As String = $"select * from [fact.facturaReferencia] where idFactura = {idFact} "
        Dim factDB = conn.llenaTabla(sqlFact)

        Dim lista As New List(Of DocumentoReferenciaSistema)

        For Each registro In factDB.Rows
            lista.Add(New DocumentoReferenciaSistema() With
            {
                .Codigo = registro.item("codigo"),
                .FechaEmision = registro.item("FechaEmision"),
                .Numero = registro.item("Numero"),
                .Razon = registro.item("Razon"),
                .TipoDoc = registro.item("TipoDoc")
            })

        Next

        Return lista

        ' [id] [idFactura] [Referencia] [TipoDoc] [Numero] [FechaEmision] [Codigo] [Razon]

        Throw New NotImplementedException()
    End Function



    Public Function getTipodocumento(Documento As String) As CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento
        Select Case Documento
            Case "01"
                Return CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento.Factura
            Case "02"
                Return CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento.NotaDebito
            Case "03"
                Return CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento.NotaCredito
            Case "04"
                Return CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento.Tiquete
            Case "05"
                Return CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento.ConfirmacionAceptacion
            Case "06"
                Return CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento.ConfirmacionAceptacionParcial
            Case "07"
                Return CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento.ConfirmacionRechazo
            Case "08"
                Return CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento.FacturaElectronicaCompra
            Case "09"
                Return CR.FacturaElectronica.Shared.EnumeradoresFEL.enmTipoDocumento.FacturaElectronicaExportacion
        End Select

    End Function


    Public Shared Function IsValidEmail(email As String) As Boolean

      If String.IsNullOrWhiteSpace(email) Then Return False

      ' Use IdnMapping class to convert Unicode domain names.
      Try
         'Examines the domain part of the email and normalizes it.
         Dim DomainMapper =
                Function(match As Match) As String

                   'Use IdnMapping class to convert Unicode domain names.
                   Dim idn = New IdnMapping

                   'Pull out and process domain name (throws ArgumentException on invalid)
                   Dim domainName As String = idn.GetAscii(match.Groups(2).Value)

                   Return match.Groups(1).Value & domainName

                End Function

         'Normalize the domain
         email = Regex.Replace(email, "(@)(.+)$", DomainMapper,
                                  RegexOptions.None, TimeSpan.FromMilliseconds(200))

      Catch e As RegexMatchTimeoutException
         Return False

      Catch e As ArgumentException
         Return False

      End Try

      Try
         Return Regex.IsMatch(email, "\s*\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*\s*",
                                 RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250))

      Catch e As RegexMatchTimeoutException
         Return False

      End Try

   End Function


End Class
