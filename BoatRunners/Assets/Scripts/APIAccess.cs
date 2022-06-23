using Newtonsoft.Json.Linq;
using System.Net.Http;
public static class APIAccess
{
    public static async void GetWeatherDataAsync()
    {
        var thisAddress =  BoatOneStatics.cityName != null? BoatOneStatics.cityName : "seattle";
        
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
}
