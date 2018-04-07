using System;
using System.IO;
using Xamarin.Forms;
using GrocerEase.iOS;

[assembly: Dependency(typeof(Helper))]
namespace GrocerEase.iOS
{
    public class Helper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}