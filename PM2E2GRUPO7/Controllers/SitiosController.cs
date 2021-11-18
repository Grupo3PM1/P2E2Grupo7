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
        public class Body
        {
            public int id { get; set; }
            public string descripcion { get; set; }
            public double latitud { get; set; }
            public double longitud { get; set; }
            //public blob fotografia { get; set; }
        }

        public class ApiSitio
        {
            public const String CrearSitio = "https://cinepolishn.000webhostapp.com/RestAPI/crear.php";
        }
       

        //METODO POST
        public async static Task CrearSitio(Models.Sitio sitio)
        {
            String json = JsonConvert.SerializeObject(sitio);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpRequestMessage response = null;
            using(HttpClient cliente =  new HttpClient())
            {
                response = await cliente.PostAsync(Models.ApiSitio.POSTSitioList, content);
            }
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Sitio Guardado");
            }
        }
    }
}
