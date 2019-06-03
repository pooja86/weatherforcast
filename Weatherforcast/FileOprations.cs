using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;

namespace Weatherforcast
{
    public class FileOprations : IFile
    {
       
        
        public IList<City> ReadFile(string FilePath)
        {
           
            var allLines = File.ReadAllLines(FilePath);
            var listOfCities = new List<City>();
            try
            { 
            foreach (var line in allLines)
            {
                var splittedLines = line.Split("=");
                if (splittedLines != null && splittedLines.Any())
                {
                    listOfCities.Add(new City
                    {
                        Id = splittedLines[0],
                        Name = splittedLines.Length > 1 ? splittedLines[1] : null,

                    });
                }

            }
        }
            catch(Exception ex)
            {
                throw ex;
            }
            return listOfCities;
        }

        public async Task<bool> WriteFile(City city, IHostingEnvironment _hostingEnvironment,dynamic content)
        {
            try
            {
                //string path = _hostingEnvironment.WebRootPath + "\\"+ DateTime.Now.ToString("ddMMyyyyHHMMSS") + city.Replace(' ','_').TrimEnd()+".txt";
                string path = CreateIfMissing(_hostingEnvironment) + "\\" + DateTime.Now.ToString("ddMMyyyyhhmmss") + city.Name.Replace(' ', '_').TrimEnd() + ".txt"; ;


                if (!File.Exists(path))
                {

                    File.WriteAllText(path, content.ToString());

                }
                else if (File.Exists(path))
                {
                    File.AppendAllText(path, content.ToString());
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }

        private string CreateIfMissing( IHostingEnvironment _hostingEnvironment)
        {
            string directorypath = "outfiles";
          string directory = Path.Combine(_hostingEnvironment.WebRootPath, directorypath);
            Directory.CreateDirectory(directory); // no need to check if it exists

            return directory;
        }
    }
}
