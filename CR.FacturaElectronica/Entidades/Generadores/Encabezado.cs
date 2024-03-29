﻿using CR.FacturaElectronica.Generadores.Detalles;
using System;


namespace CR.FacturaElectronica.Entidades
{
    public class Encabezado
    {
        internal string Clave { get; set; }
        public string CodigoActividad { get; set; }
        internal string NumeroConsecutivo { get; set; }
        internal DateTime FechaEmision { get; set; }
        internal Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public string[] MediosPago { get; set; }
        public string CondicionVenta { get; set; }
        public string PlazoCredito { get; set; }
        public string NormativaNombre { get; set; }
        public string NormativaFecha { get; set; }

    }
}
