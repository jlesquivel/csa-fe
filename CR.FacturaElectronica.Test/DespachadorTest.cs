﻿using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Test
{
    public class DespachadorTest
    {
        public void Ejecutar()
        {
            var config = new ConfiguracionComunicacionHacienda
            {
               ClientID          = "api-stag",
               ClientSecret      = "",
               GrantType         = "password",
               TipoAutenticacion = "bearer",
               UrlApiHacienda    = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/recepcion",
               UrlIdpLogIn       = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token",
               UrlIdpLogOut      = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/logout",
               IdpUsuario        = "cpf-05-0269-0349@stag.comprobanteselectronicos.go.cr", 
               IdpContrasenna    = "E>++}6U6W:;rE?gvF;-("
            };
         
            var despechador = new DespachadorDocumentosAHacienda(config);

            List<DocumentoDto> listadocs = new List<DocumentoDto>();
            DocumentoDto doc = new DocumentoDto {
                clave = "50622101800030385010000100001010000000493140264212", //la clave de 50 caracteres
                comprobanteXml = "<Tiquete Electronico></TiqueteElectronico>", //el comprobante en formato XML
                emisor = new PersonaDocumentoDto { //la informacion del emisor
                     numeroIdentificacion = "304810266",
                     tipoIdentificacion = "02"
                },
                receptor = new PersonaDocumentoDto { //la info del receptor
                    numeroIdentificacion = "909990999",
                    tipoIdentificacion = "02"
                },
                fecha = DateTime.Now.ToString("yyyy-MM-dd'T'HH:mm:ssZ") //la fecha de la factura-> cuando la factura se hizo
            };
            listadocs.Add(doc);

            var resp = despechador.EjecutarProceso(listadocs);

            Console.WriteLine(resp[0]);


        }
    }
}
