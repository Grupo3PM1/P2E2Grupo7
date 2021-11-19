using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PM2E2GRUPO7.Controllers
{
    class SitiosController
    {
        

        public class ApiSitio
        {
            public const String CrearSitio = "https://cinepolishn.000webhostapp.com/RestAPI/crear.php";
        }


        //METODO POST
        public async static Task CrearSitio(Models.Sitio sitio)
        {
            String json = JsonConvert.SerializeObject(sitio);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            using (HttpClient cliente = new HttpClient())
            {
                response = await cliente.PostAsync(Models.ApiSitio.POSTSitioList, content);
            }
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Sitio Guardado");
            }
            else
            {
                Debug.WriteLine("ERROR");
            }
        }


        //METODO GET

        public async static Task<List<Models.Sitio>> GetListSitios()
        {
            List<Models.Sitio> listsitio = new List<Models.Sitio>();
            using (HttpClient client = new HttpClient()) 
            {
                var response = await client.GetAsync(Models.ApiSitio.GETSitioList);

                if (response.IsSuccessStatusCode) {
                    var JsonContent = response.Content.ReadAsStringAsync().Result;
                    var SitioDes = JsonConvert.DeserializeObject<Models.SitioRoot>(JsonContent);
                    listsitio = SitioDes.sitios as List<Models.Sitio>;
                }
            }
            return listsitio;
        }

        //METODO UPDATE
        public async static Task UpdateSitio(Models.Sitio sitio)
        {
            String JsonContent = JsonConvert.SerializeObject(sitio);
            StringContent contenido = new StringContent(JsonContent,Encoding.UTF8,"application/json");
            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient())
            {
                response = await client.PostAsync(Models.ApiSitio.UPDATESitioList,contenido);
            }
            if (response.IsSuccessStatusCode)
            {
                var respuesta = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Sitio Actulizado");
            }
            else
            {
                Debug.WriteLine("ERROR");
            }
        }


        //METODO DELETE
        public async static Task DeleteSitio(Models.Sitio sitio)
        {
            String JsonContent = JsonConvert.SerializeObject(sitio);
            StringContent contenido = new StringContent(JsonContent, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            using (HttpClient client = new HttpClient())
            {
                response = await client.PostAsync(Models.ApiSitio.DELETESitioList, contenido);
            }
            if (response.IsSuccessStatusCode)
            {
                var respuesta = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine("Sitio Eliminado");
            }
            else
            {
                Debug.WriteLine("ERROR");
            }
        }



    }
}
