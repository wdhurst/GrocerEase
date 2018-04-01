using System;t
using System;
using System.IO;
using GrocerEase.iOS;

using Xamarin.Forms;
[assembly: Dependency(typeof(IFileHelper))]
namespace GrocerEase.iOS
{
    {
        public class IFileHelper : IFileHelper
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
}

