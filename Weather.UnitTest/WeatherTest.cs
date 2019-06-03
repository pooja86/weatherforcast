using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using weather.Utilities;
using Xunit;
namespace Weather.UnitTest
{
  public  class WeatherTest
    {
        string cityID = "";

        string Appid = "b6907d289e10d714a6e88b30761fae22";
        string appurl = "https://samples.openweathermap.org";
        public WeatherTest()
        {
            cityID = "2172797";
           
        }
        [Fact]
        public async void isweatherDeatilsPresentAsync()
        {
            using (var client = new HttpClient())
            {
                var result = "";

                client.BaseAddress = new Uri(appurl);
                var response = await client.GetAsync($"/data/2.5/weather?id={cityID}&appid=" + Appid);
                response.EnsureSuccessStatusCode(); response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                    Assert.True(true);
            }
        }


        [Fact]
        public async void isweatherDeatilsNotPresentAsync()
        {
            cityID = "2172ff797";
            using (var client = new HttpClient())
            {
                var result = "";

                client.BaseAddress = new Uri(appurl);
                var response = await client.GetAsync($"/data/2.5/weather?id={cityID}&appid=" + Appid);
                response.EnsureSuccessStatusCode(); response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                    Assert.False(false);
            }
        }
    }
}
