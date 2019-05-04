using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using WeatherWebsite.Models;

namespace WeatherWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //var parser = new JavaScriptSerializer();
            var source = "{\"coord\":{\"lon\":-77.94,\"lat\":34.23},\"weather\":[{\"id\":804,\"main\":\"Clouds\",\"description\":\"overcast clouds\",\"icon\":\"04d\"}],\"base\":\"stations\",\"main\":{\"temp\":75.47,\"pressure\":1014,\"humidity\":88,\"temp_min\":73,\"temp_max\":78.01},\"visibility\":16093,\"wind\":{\"speed\":3.36,\"deg\":350},\"clouds\":{\"all\":90},\"dt\":1556977638,\"sys\":{\"type\":1,\"id\":4521,\"message\":0.0057,\"country\":\"US\",\"sunrise\":1556965163,\"sunset\":1557014256},\"id\":4499379,\"name\":\"Wilmington\",\"cod\":200}";
            var info = JsonConvert.DeserializeObject<WeatherModel>(source);
            return View(info);
        }

    }
}