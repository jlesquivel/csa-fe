﻿using System;
using System.Collections.Generic;
using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Generadores.Detalles;
using CR.FacturaElectronica.Interfaces;
using CR.FacturaElectronica.Shared;
using CR.FacturaElectronica.Generadores.Encabezados;
using System.Linq;

namespace CR.FacturaElectronica.Generadores
{
    internal class GeneradorXML : IGeneradorXML
    {
        public List<LineaDetalle> Detalles { get; set; }
        public Encabezado Encabezado { get; set; }
        public ResumenFactura Resumen { get; set; }
        public DocumentoReferenciaSistema[] DocsReferencia { get; set; }
        public Dictionary<string, string> SeccionOtros { get; set; }

        public string CrearXML(EnumeradoresFEL.enmTipoDocumento tipoDoc)
        {

            var encDoc = ResolverEncabezado(tipoDoc);
            encDoc.CodigoActividad = Encabezado.CodigoActividad;
            encDoc.Clave = Encabezado.Clave;
            encDoc.NumeroConsecutivo = Encabezado.NumeroConsecutivo;
            encDoc.FechaEmision = Encabezado.FechaEmision;
            encDoc.Emisor = Encabezado.Emisor;
            encDoc.Receptor = Encabezado.Receptor;
            encDoc.CondicionVenta = ModFunciones.ObtenerValorEnumerador(Encabezado.CondicionVenta, 
                Enumeradores.CondicionVenta.Item99);
            encDoc.PlazoCredito = Encabezado.PlazoCredito;
            encDoc.MedioPago = AsignarMediosPago();
            encDoc.DetalleServicio = Detalles.ToArray();
            encDoc.ResumenFactura = Resumen;
            encDoc.InformacionReferencia = CrearArregloReferencias();
         
            encDoc.Otros = CrearSeccionOtros();
            return encDoc.GenerarXML();

            throw new NotImplementedException();
        }

        private Otros CrearSeccionOtros()
        {
            if (SeccionOtros == null) return null;
            var otros = new Otros();
            var listaOtroTexto = new List<OtrosOtroTexto>();
            SeccionOtros.ToList().ForEach(t => {
                listaOtroTexto.Add(new OtrosOtroTexto {
                    codigo = t.Key,
                    Value = t.Value
                });
            });
            otros.OtroTexto = listaOtroTexto.ToArray();
            return otros;
        }

        private InformacionReferencia[] CrearArregloReferencias()
        {
            if (DocsReferencia == null || DocsReferencia.Length <= 0) return null;
            var lista = new List<InformacionReferencia>();
            DocsReferencia.ToList().ForEach(t =>
            {
                lista.Add(new InformacionReferencia
                {
                    FechaEmision = t.FechaEmision,
                    Numero =t.Numero,
                    Razon = t.Razon,
                    Codigo = ModFunciones.ObtenerValorEnumerador(t.Codigo, InformacionReferencia.InformacionReferenciaCodigo.Item99),
                    TipoDoc = ModFunciones.ObtenerValorEnumerador(t.TipoDoc, InformacionReferencia.TipoDocumento.Item99)
            });
            });

            return lista.ToArray();

       
        }

        private Enumeradores.MedioPago[] AsignarMediosPago()
        {
            var arrMediosPago = new Enumeradores.MedioPago[Encabezado.MediosPago.Length];
            for (int i = 0; i < Encabezado.MediosPago.Length; i++)
            {
                arrMediosPago[i] = ModFunciones.ObtenerValorEnumerador(Encabezado.MediosPago[i], Enumeradores.MedioPago.Item99);
            }
            return arrMediosPago;
        }

        private IEncabezado ResolverEncabezado(EnumeradoresFEL.enmTipoDocumento tipoDoc)
        {
            switch (tipoDoc)
            {
                case EnumeradoresFEL.enmTipoDocumento.Factura:
                    return new Encabezados.FacturaElectronica();
                case EnumeradoresFEL.enmTipoDocumento.NotaCredito:
                    return new NotaCreditoElectronica();
                case EnumeradoresFEL.enmTipoDocumento.NotaDebito:
                    return new NotaDebitoElectronica();
                case EnumeradoresFEL.enmTipoDocumento.Tiquete:
                    return new TiqueteElectronico();
                default:
                    throw new NotSupportedException("Tipo de documento no soportado");
            }
        }
    }
}
