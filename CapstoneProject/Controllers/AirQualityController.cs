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

        public ActionResult Search() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(string city)
        {
            HttpClient client = new HttpClient();
            string lat = "";
            string lng = "";
            var response = client.GetAsync($"https://maps.googleapis.com/maps/api/geocode/json?address={city},+USA&key=AIzaSyB9vTooAefcwsjXzOv-CMWtPbgUq7TpUFY");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();
                var content = read.Result;
                JObject jObject = JObject.Parse(content);
                lat = (string)jObject["geometry"]["location"]["lat"];
                lng = (string)jObject["geometry"]["location"]["lng"];
            }
            return RedirectToAction("Index", new { City = city });
        }

        public ActionResult Index(string City)
        {
            string latit;
            string longit;
            HttpClient client = new HttpClient();
            string lat="";
            string lng = "";
            var response = client.GetAsync($"https://maps.googleapis.com/maps/api/geocode/json?address={City},+USA&key=AIzaSyB9vTooAefcwsjXzOv-CMWtPbgUq7TpUFY");
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
                    lat = (string)item["geometry"]["location"]["lat"];
                    lng = (string)item["geometry"]["location"]["lng"];
                    break;
                }
            }

            latit = lat;
            longit = lng;

            List<string> latList = new List<string>();
            List<string> lngList = new List<string>();
           // HttpClient client = new HttpClient();
            response = client.GetAsync("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=" + latit + "," + longit + "&radius=1609&type=hospital&keyword=emergency&hospital&key=" + PrivateKeys.googleplacesKey);
            response.Wait();
            result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var read = result.Content.ReadAsStringAsync();
                read.Wait();                
                var content = read.Result;
                JObject jArray = JObject.Parse(content);
                var list = (JArray)jArray["results"];
                foreach (var item in list)
                {
                    var lat1 = (string)item["geometry"]["location"]["lat"];
                    latList.Add(lat1);
                    var lng1 = (string)item["geometry"]["location"]["lng"];
                    lngList.Add(lng1);
                }
            }
            LatLngViewModel latLng = new LatLngViewModel();
            ViewBag.Url = "https://maps.googleapis.com/maps/api/js?key=" + PrivateKeys.googleMap;
            ViewBag.Lat = latit;
            ViewBag.Lng = longit;
            latLng.Lat = latList;
            latLng.Lng = lngList;
            return View(latLng);
        }
    }
}