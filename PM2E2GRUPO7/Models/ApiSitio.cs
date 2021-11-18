using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E2GRUPO7.Models
{
    public static class UrlApi
    {
        public static string ip = "192.168.0.5";
        public static string web = "CRUD-PHP";

        //Apis clase sitios
        public static string getEndPoint = "listasitios.php";
        public static string postEndPoint = "crear.php";
    }
    public static class ApiSitio
    {
        public static string POSTSitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.getEndPoint);

    }

    public class Sitio
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
    }

    
}
