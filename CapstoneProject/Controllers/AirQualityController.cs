using CapstoneProject.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CapstoneProject.Controllers
{
    public class AirQualityController : Controller
    {
        // GET: AirQuality
        public ActionResult Index()
        {
            List<string> latList = new List<string>();
            List<string> lngList = new List<string>();
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=43.0392,-87.9084&radius=1609&type=hospital&keyword=emergency&hospital&key=googleplacesKey");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();                
                var content = read.Result;
                JObject jArray = JObject.Parse(content);
                var list = (JArray)jArray["results"];
                foreach (var item in list)
                {
                    var lat = (string)item["geometry"]["location"]["lat"];
                    latList.Add(lat);
                    var lng = (string)item["geometry"]["location"]["lng"];
                    lngList.Add(lng);
                }
            }
            LatLngViewModel latLng = new LatLngViewModel();
            latLng.Lat = latList;
            latLng.Lng = lngList;
            return View(latLng);
        }
    }
}