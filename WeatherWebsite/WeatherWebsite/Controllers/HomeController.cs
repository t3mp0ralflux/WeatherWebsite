using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.UI;
using Logger;
using Newtonsoft.Json;
using WeatherWebsite.Models;

namespace WeatherWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var webReq = (HttpWebRequest) WebRequest.Create(
                $"http://api.openweathermap.org/data/2.5/weather?id=4499379&units=imperial&APPID=INSERTKEYHERE");  //gotta put the api key here
            webReq.Method = "GET";
            Log.LogDebug(GetType(),"Getting Weather");

            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)webReq.GetResponse();
            }
            catch (Exception e)
            {
                Log.LogError(GetType(),"Trying to get weather data", e);
                throw;
            }
            

            string source;
            using (var stream = response.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                var reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                source = reader.ReadToEnd();
            }


            //var source = "{\"coord\":{\"lon\":-77.94,\"lat\":34.23},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":75.47,\"pressure\":1014,\"humidity\":88,\"temp_min\":73,\"temp_max\":78.01},\"visibility\":16093,\"wind\":{\"speed\":3.36,\"deg\":350},\"clouds\":{\"all\":90},\"dt\":1556977638,\"sys\":{\"type\":1,\"id\":4521,\"message\":0.0057,\"country\":\"US\",\"sunrise\":1556965163,\"sunset\":1557014256},\"id\":4499379,\"name\":\"Wilmington\",\"cod\":200}";
            var info = JsonConvert.DeserializeObject<WeatherModel>(source);
            return View(info);
        }

        

    }
}