using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using weather.Utilities;

namespace Weatherforcast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFile file;
        private readonly Iweather weather;
        public WeatherController(IHostingEnvironment hostingEnvironment,IFile _file, Iweather _weather)
        {
            _hostingEnvironment = hostingEnvironment;
            file = _file;
            weather = _weather;
        }
        [HttpGet]
        public async Task<bool> Get()
        {
            bool isfilecreated = true;
            string path = @_hostingEnvironment.WebRootPath + "\\InputFile\\Weather.txt";
            // string path = @"C:\Pooja\Training\Files\Weather.txt";
            try
            {
                IList<City> cities = file.ReadFile(path);

                foreach (City c in cities)
                {

                    dynamic res = await weather.getWeatherDetailsAsync(c.Id);
                    isfilecreated = await file.WriteFile(c, _hostingEnvironment, res);
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return isfilecreated;
        }
    }
}