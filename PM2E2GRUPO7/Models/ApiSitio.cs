using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E2GRUPO7.Models
{
    public static class UrlApi
    {
        public static string ip = "cinepolishn.000webhostapp.com";
        public static string web = "RestAPI";


        //Apis clase sitios
        public static string getEndPoint = "listasitios.php"; //GET
        public static string postEndPoint = "crear.php"; //POST
        public static string updateEndPoint = "actualizarsitio.php"; //UPDATE
        public static string deleteEndPoint = "eliminarsitio.php"; //DELETE

    }
    public static class ApiSitio
    {
        public static string GETSitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.getEndPoint);
        public static string POSTSitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.postEndPoint);
        public static string UPDATESitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.updateEndPoint);
        public static string DELETESitioList = string.Format("http://{0}/{1}/{2}", UrlApi.ip, UrlApi.web, UrlApi.deleteEndPoint);

    }

    public class Sitio
    {
        public string id { get; set; }
        public string descripcion { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }

    } 

    public class SitioRoot
    {
        public IList<Sitio> sitios { get; set; }
    }


}
