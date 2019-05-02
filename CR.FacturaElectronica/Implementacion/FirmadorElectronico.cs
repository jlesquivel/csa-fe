using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Interfaces;
using FirmaXadesNet;
using FirmaXadesNet.Crypto;
using FirmaXadesNet.Signature.Parameters;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;



namespace CR.FacturaElectronica
{
    internal class FirmadorElectronico : IFirmadorElectronico
    {
        private readonly ConfiguracionCreacionDocumentos _configuracion;

        public FirmadorElectronico(ConfiguracionCreacionDocumentos configuracion)
        {
            this._configuracion = configuracion;
        }

        // original **************************///////////////////////*****************************
        public string FirmarDocumento(string rutaGuardado)
        {
            var certificado = new X509Certificate2(_configuracion.LlaveCriptograficaRuta, _configuracion.LlaveCriptograficaClave, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
            var servicioFirma = new XadesService();
            var parametros = ObtenerParametros();
            using (parametros.Signer = new Signer(certificado))
            {
                using (var fileStream = new FileStream(rutaGuardado, FileMode.Open))
                {
                    var docFirmado = servicioFirma.Sign(fileStream, parametros);
                    fileStream.Close();
                    docFirmado.Save(rutaGuardado);
                }

            }
            using (var lector = new StreamReader(rutaGuardado))
            {
                var xmlFirmado = lector.ReadToEnd();
                return xmlFirmado;

            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private SignatureParameters ObtenerParametros()
        {
            var parametrosFirma = new SignatureParameters();
            parametrosFirma.SignaturePolicyInfo = new SignaturePolicyInfo();
            parametrosFirma.SignaturePolicyInfo.PolicyIdentifier = _configuracion.Politica;
            parametrosFirma.SignaturePolicyInfo.PolicyHash = _configuracion.PoliticaDigest;
            parametrosFirma.SignaturePolicyInfo.PolicyDigestAlgorithm = DigestMethod.SHA256;
            parametrosFirma.SignaturePackaging = SignaturePackaging.ENVELOPED;
            //parametrosFirma.InputMimeType = "text/xml";
            parametrosFirma.SignerRole = new SignerRole();
            parametrosFirma.SignerRole.ClaimedRoles.Add("emisor");

            return parametrosFirma;
        }


        //public string FirmarDocumento(string pathXML )
        //{
        //    try
        //    {
        //        X509Certificate2 cert;
        //        cert = new X509Certificate2(_configuracion.LlaveCriptograficaRuta, _configuracion.LlaveCriptograficaClave);

        //        XadesService xadesService = new XadesService();
        //        SignatureParameters parametros = new SignatureParameters();

        //        parametros.SignaturePolicyInfo = new SignaturePolicyInfo();
        //        parametros.SignaturePolicyInfo.PolicyIdentifier = "https://tribunet.hacienda.go.cr/docs/esquemas/2016/v4.1/Resolucion_Comprobantes_Electronicos_DGT-R-48-2016.pdf";
        //        //La propiedad PolicyHash es la misma para todos, es un cálculo en base al archivo pdf indicado en PolicyIdentifier
        //        parametros.SignaturePolicyInfo.PolicyHash = "Ohixl6upD6av8N7pEvDABhEL6hM=";
        //        parametros.SignaturePackaging = SignaturePackaging.ENVELOPED;               
        //        //parametros.DataFormat = new DataFormat();
        //        parametros.Signer = new FirmaXadesNet.Crypto.Signer(cert);

        //        FileStream fs = new FileStream(pathXML, FileMode.Open);
        //        FirmaXadesNet.Signature.SignatureDocument docFirmado = xadesService.Sign(fs, parametros);

        //        fs.Close();
        //        docFirmado.Save((pathXML));

        //        using (var lector = new StreamReader(pathXML))
        //        {
        //            var xmlFirmado = lector.ReadToEnd();
        //            return xmlFirmado;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}     



    }

}
