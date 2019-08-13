using CR.FacturaElectronica.Generadores.Detalles;
using CR.FacturaElectronica.Interfaces;
using CR.FacturaElectronica.Shared;
using System;
using System.Xml.Serialization;

namespace CR.FacturaElectronica.Generadores.Encabezados
{
    /// <comentarios/>
    /// 

    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/facturaElectronica")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/facturaElectronica", IsNullable = false)]
  
    public class FacturaElectronica : IEncabezado
    {


        private string SchemaLocation = "https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/facturaElectronica https://cdn.comprobanteselectronicos.go.cr/xml-schemas/v4.3/facturaElectronica_V.4.3.xsd";

        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string schemaLocation
        {
            get
            {
                return SchemaLocation;
            }
            set
            {
                SchemaLocation = value;
            }
        }


        public string Clave { get; set; }

        public string CodigoActividad { get; set; }
        public string NumeroConsecutivo { get; set; }

        [XmlIgnore]
        public DateTime FechaEmision { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("FechaEmision")]
        public string SomeDateString
        {
            get { return this.FechaEmision.ToString("yyyy-MM-ddTHH:mm:ss.fff"); }
            set { this.FechaEmision = DateTime.Parse(value); }
        }

        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public Enumeradores.CondicionVenta CondicionVenta { get; set; }
        public string PlazoCredito { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("MedioPago")]
        public Enumeradores.MedioPago[] MedioPago { get; set; }
        [System.Xml.Serialization.XmlArrayItemAttribute("LineaDetalle", IsNullable = false)]
        public LineaDetalle[] DetalleServicio { get; set; }
        public ResumenFactura ResumenFactura { get; set; }
        [System.Xml.Serialization.XmlElementAttribute("InformacionReferencia")]
        public InformacionReferencia[] InformacionReferencia { get; set; }
        public Normativa Normativa { get; set; }
        public Otros Otros { get; set; }

        public string GenerarXML()
        {
            return ModFunciones.ObtenerXMLComoString(this);
        }
    }
}
