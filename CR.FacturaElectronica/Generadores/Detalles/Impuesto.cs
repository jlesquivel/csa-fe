namespace CR.FacturaElectronica.Generadores.Detalles
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public class Impuesto
    {

        private decimal factorIVAField;
        private bool factorIVAFieldSpecified;

        public ImpuestoCodigo  Codigo{ get; set; }
        public ImpuestoTypeCodigoTarifa CodigoTarifa { get; set; }
        public decimal Tarifa { get; set; }
        public decimal FactorIVA
        {
            get
            {
                return this.factorIVAField;
            }
            set
            {
                this.factorIVAField = value;
            }
        }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FactorIVASpecified
        {
            get
            {
                return this.factorIVAFieldSpecified;
            }
            set
            {
                this.factorIVAFieldSpecified = value;
            }
        }
        public decimal Monto { get; set; }
        public Exoneracion Exoneracion { get; set; }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
        [System.SerializableAttribute()]
        public enum ImpuestoCodigo {
            /// <comentarios/ Impuesto al Valor Agregado >
            [System.Xml.Serialization.XmlEnumAttribute("01")]
            Item01,

            /// <comentarios/ Impuesto Selectivo de Consumo >
            [System.Xml.Serialization.XmlEnumAttribute("02")]
            Item02,

            /// <comentarios/ Impuesto Único a los Combustibles>
            [System.Xml.Serialization.XmlEnumAttribute("03")]
            Item03,

            /// <comentarios/ Impuesto específico de Bebidas Alcohólicas >
            [System.Xml.Serialization.XmlEnumAttribute("04")]
            Item04,

            /// <comentarios/ Impuesto Específico sobre las bebidas envasadas sin contenido alcohólico y jabones de tocador  >
            [System.Xml.Serialization.XmlEnumAttribute("05")]
            Item05,

            /// <comentarios/ Impuesto a los Productos de Tabaco >
            [System.Xml.Serialization.XmlEnumAttribute("06")]
            Item06,

            /// <comentarios/ IVA (cálculo especial)>
            [System.Xml.Serialization.XmlEnumAttribute("07")]
            Item07,
            

            /// <comentarios/ IVA Régimen de Bienes Usados (Factor) >
            [System.Xml.Serialization.XmlEnumAttribute("08")]
            Item08,


            /// <comentarios/ Impuesto Específico al Cemento >
            [System.Xml.Serialization.XmlEnumAttribute("12")]
            Item12,

            /// <comentarios/  Otros >
            [System.Xml.Serialization.XmlEnumAttribute("99")]
            Item99,


        }

        public enum ImpuestoTypeCodigoTarifa
        {

            /// <remarks/ Tarifa 0% (Exento)  >
            [System.Xml.Serialization.XmlEnumAttribute("01")]
            Item01,

            /// <remarks/ Tarifa reducida 1% >
            [System.Xml.Serialization.XmlEnumAttribute("02")]
            Item02,

            /// <remarks/ Tarifa reducida 2% >
            [System.Xml.Serialization.XmlEnumAttribute("03")]
            Item03,

            /// <remarks/ Tarifa reducida 4%  >
            [System.Xml.Serialization.XmlEnumAttribute("04")]
            Item04,

            /// <remarks/ Transitorio 0%, >
            [System.Xml.Serialization.XmlEnumAttribute("05")]
            Item05,

            /// <remarks/ Transitorio 4%  >
            [System.Xml.Serialization.XmlEnumAttribute("06")]
            Item06,

            /// <remarks/ Tarifa general 13%>
            [System.Xml.Serialization.XmlEnumAttribute("07")]
            Item07,

            /// <remarks/>
            [System.Xml.Serialization.XmlEnumAttribute("08")]
            Item08,
        }
    }
}