using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Weatherforcast
{
    public interface Iweather
    {

        Task<dynamic> getWeatherDetailsAsync(string cityID);
    }
}
