namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class ResumenFactura
    {

        [System.Xml.Serialization.XmlElementAttribute("CodigoTipoMoneda")]
        public CodigoTypeMoneda Moneda { get; set; }

        public decimal TotalServGravados { get; set; }

        public decimal TotalServExentos { get; set; }

        public decimal TotalServExonerado { get; set; }

        public decimal TotalMercanciasGravadas { get; set; }

        public decimal TotalMercanciasExentas { get; set; }

        public decimal TotalMercExonerada { get; set; }

        public decimal TotalGravado { get; set; }

        public decimal TotalExento { get; set; }

        public decimal TotalExonerado { get; set; }

        public decimal TotalVenta { get; set; }

        public decimal TotalDescuentos { get; set; }

        public decimal TotalVentaNeta { get; set; }

        public decimal TotalImpuesto { get; set; }

        public decimal TotalComprobante { get; set; }
       
    }
}