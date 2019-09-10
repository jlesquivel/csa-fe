using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class LineaDetalle
    {
        [System.Xml.Serialization.XmlElementAttribute(DataType = "positiveInteger")]
        public string NumeroLinea { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("CodigoComercial")]
        public CodigoType[] Codigo { get; set; }

        public decimal Cantidad { get; set; }
        public UnidadMedidaType UnidadMedida { get; set; }
        public string UnidadMedidaComercial { get; set; }
        public string Detalle { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoDescuento { get; set; }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MontoDescuentoSpecified { get; set; }

        public string NaturalezaDescuento { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NaturalezaDescuentoSpecified { get; set; }

        public decimal SubTotal { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("Impuesto")]
        public Impuesto[] Impuesto { get; set; }

        public decimal ImpuestoNeto { get; set; }    


        public decimal MontoTotalLinea { get; set; }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]

        public enum UnidadMedidaType
        {

            /// <remarks/>
            Al,

            /// <remarks/>
            Alc,

            /// <remarks/>
            Cm,

            /// <remarks/>
            I,

            /// <remarks/>
            Os,

            /// <remarks/>
            Sp,

            /// <remarks/>
            Spe,

            /// <remarks/>
            St,

            /// <remarks/>
            m,

            /// <remarks/>
            kg,

            /// <remarks/>
            s,

            /// <remarks/>
            A,

            /// <remarks/>
            K,

            /// <remarks/>
            mol,

            /// <remarks/>
            cd,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("m²")]
            m1,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("m³")]
            m2,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("m/s")]
            ms,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("m/s²")]
            ms1,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("1/m")]
            Item1m,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("kg/m³")]
            kgm,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("A/m²")]
            Am,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("A/m")]
            Am1,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("mol/m³")]
            molm,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("cd/m²")]
            cdm,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("1")]
            Item1,

            /// <remarks/>
            rad,

            /// <remarks/>
            sr,

            /// <remarks/>
            Hz,

            /// <remarks/>
            N,

            /// <remarks/>
            Pa,

            /// <remarks/>
            J,

            /// <remarks/>
            W,

            /// <remarks/>
            C,

            /// <remarks/>
            V,

            /// <remarks/>
            F,

            /// <remarks/>
            Ω,

            /// <remarks/>
            S,

            /// <remarks/>
            Wb,

            /// <remarks/>
            T,

            /// <remarks/>
            H,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("°C")]
            C1,

            /// <remarks/>
            lm,

            /// <remarks/>
            lx,

            /// <remarks/>
            Bq,

            /// <remarks/>
            Gy,

            /// <remarks/>
            Sv,

            /// <remarks/>
            kat,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("Pa·s")]
            Pas,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("N·m")]
            Nm,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("N/m")]
            Nm1,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("rad/s")]
            rads,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("rad/s²")]
            rads1,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("W/m²")]
            Wm,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("J/K")]
            JK,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("J/(kg·K)")]
            JkgK,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("J/kg")]
            Jkg,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("W/(m·K)")]
            WmK,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("J/m³")]
            Jm,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("V/m")]
            Vm,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("C/m³")]
            Cm1,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("C/m²")]
            Cm2,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("F/m")]
            Fm,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("H/m")]
            Hm,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("J/mol")]
            Jmol,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("J/(mol·K)")]
            JmolK,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("C/kg")]
            Ckg,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("Gy/s")]
            Gys,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("W/sr")]
            Wsr,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("W/(m²·sr)")]
            Wmsr,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("kat/m³")]
            katm,

            /// <remarks/>
            min,

            /// <remarks/>
            h,

            /// <remarks/>
            d,

            /// <remarks/>
            º,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("´")]
            Item,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("´´")]
            Item2,

            /// <remarks/>
            L,

            /// <remarks/>
            t,

            /// <remarks/>
            Np,

            /// <remarks/>
            B,

            /// <remarks/>
            eV,

            /// <remarks/>
            u,

            /// <remarks/>
            ua,

            /// <remarks/>
            Unid,

            /// <remarks/>
            Gal,

            /// <remarks/>
            g,

            /// <remarks/>
            Km,

            /// <remarks/>
            Kw,

            /// <remarks/>
            ln,

            /// <remarks/>
            cm,

            /// <remarks/>
            mL,

            /// <remarks/>
            mm,

            /// <remarks/>
            Oz,

            /// <remarks/>
            Otros,
        }

    }
}



