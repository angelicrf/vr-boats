using Newtonsoft.Json.Linq;
using System.Net.Http;
using UnityEngine;

public static class APIAccess
{
    public static async void GetWeatherDataAsync()
    {
        var thisAddress = BoatOneStatics.cityName != null ? BoatOneStatics.cityName : "seattle";

        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{thisAddress}?unitGroup=metric&key=93UBMXKNCNN7CUYLSPDRL3DJU&contentType=json");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(body);
        BoatOneStatics.city = json.GetValue("address").ToString();
        for (int i = 0; i < 1; i++)
        {
            BoatOneStatics.dateW = json.GetValue("days")[i]["datetime"].ToString();
            BoatOneStatics.descriptionW = json.GetValue("days")[i]["description"].ToString();
            BoatOneStatics.tempMin = json.GetValue("days")[i]["tempmin"].ToString();
            BoatOneStatics.tempMax = json.GetValue("days")[i]["tempmax"].ToString();
        }

    }
    public async static void PostUserLocation()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "https://www.googleapis.com/geolocation/v1/geolocate?key=AIzaSyA091OMJ7QWITTREIN87ifnwYaVq0Emcvs");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadAsStringAsync();
        JObject json = JObject.Parse(body);
        var newLang = json.SelectToken("$.location.lng").Value<string>();
        var newLat = json.SelectToken("$.location.lat").Value<string>();
        
    }
    public async static void GetUserMapStaticLocation()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "https://maps.googleapis.com/maps/api/staticmap?size=512x512&maptype=roadmap&markers=size:mid%7Ccolor:red%7CSan+Francisco,CA%7COakland,CA%7CSan+Jose,CA&key=AIzaSyA091OMJ7QWITTREIN87ifnwYaVq0Emcvs");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            Debug.Log("succeed");
        }
    }
    public async static void GetUserMapDirectionLocation()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "https://maps.googleapis.com/maps/api/directions/json?origin=Boston,MA&destination=Concord,MA&waypoints=Charlestown,MA|via:Lexington,MA&key=AIzaSyA091OMJ7QWITTREIN87ifnwYaVq0Emcvs");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        if (response.IsSuccessStatusCode)
        {
            var body = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(body);
            var newRoutes = json["routes"] as JArray;
            var points = newRoutes[0]["overview_polyline"]["points"];
        }
    }
}
