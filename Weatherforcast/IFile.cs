using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weatherforcast
{
    public interface IFile
    {
        //this will atke care of file oprations
         IList<City> ReadFile(string FilePath);
        Task<bool> WriteFile(City city, IHostingEnvironment _hostingEnvironment,dynamic content);
    }
}
