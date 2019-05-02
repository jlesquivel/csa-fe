using CR.FacturaElectronica.Entidades;
using CR.FacturaElectronica.Procesos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.FacturaElectronica.Test
{
    public class ConsultorTest
    {
        public void Consultar(string llave)
        {
            var config = new ConfiguracionComunicacionHacienda
            {
                ClientID = "api-stag",
                ClientSecret = "",
                GrantType = "password",
                TipoAutenticacion = "bearer",
                UrlApiHacienda = "https://api.comprobanteselectronicos.go.cr/recepcion-sandbox/v1/recepcion",
                UrlIdpLogIn = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/token",
                UrlIdpLogOut = "https://idp.comprobanteselectronicos.go.cr/auth/realms/rut-stag/protocol/openid-connect/logout",
                IdpUsuario = "cpf-05-0269-0349@stag.comprobanteselectronicos.go.cr",
                IdpContrasenna = "E>++}6U6W:;rE?gvF;-("
            };

            var consultor = new ConsultorDocumentosEnHacienda(config);
            List<string> llaves = new List<string>();
            llaves.Add(llave);
            var resultado = consultor.EjecutarProceso(llaves);

            Console.WriteLine(resultado[0].Estado.indEstado);


            Console.WriteLine(resultado[0].Estado.respuestaXml);
        }
    }
}
