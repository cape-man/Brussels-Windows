using Brussels.FlightSearch.Abstract;
using Brussels.FlightSearch.UWP.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Brussels.FlightSearch.UWP.Framework
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }

        public string ReadFile(string filename)
        {
            string fileContent = string.Empty;

            if (File.Exists(filename))
            {
                fileContent = File.ReadAllText(filename);
            }

            return fileContent;
        }

        public bool IsFileExist(string filename)
        {

            return File.Exists(filename);
        }
    }
}
