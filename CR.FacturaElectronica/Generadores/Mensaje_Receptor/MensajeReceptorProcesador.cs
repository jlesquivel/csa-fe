
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace CR.FacturaElectronica.Mensaje_Receptor


{
    public partial class MensajeReceptorProcesador 
    {
        
        // Guarda el XML en un archivo fisico
        public string fcObtenerStringXML(MensajeReceptor pvoTiquete)
        {
            try
            {
                
                //Crea Objeto serializador
                XmlSerializer vloSerializador = new XmlSerializer(typeof(MensajeReceptor));
                //Define las configuraciones
                XmlWriterSettings vloConfiguraciones = new XmlWriterSettings();
                //Asinga los valores
                vloConfiguraciones.Encoding = new UnicodeEncoding(false, false); 
                vloConfiguraciones.Indent = true;
                vloConfiguraciones.OmitXmlDeclaration = false;

                using (StringWriter vloEscritor = new StringWriterWithEncoding(Encoding.UTF8))
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(vloEscritor, vloConfiguraciones))
                    {
                        vloSerializador.Serialize(xmlWriter, pvoTiquete);
                    }
                    //Antes de retornarlo lo guarda 
                    return vloEscritor.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public class StringWriterWithEncoding : StringWriter
    {
        private Encoding myEncoding;
        public override Encoding Encoding
        {
            get
            {
                return myEncoding;
            }
        }
        public StringWriterWithEncoding(Encoding encoding)
            : base()
        {
            myEncoding = encoding;
        }
    }

}
