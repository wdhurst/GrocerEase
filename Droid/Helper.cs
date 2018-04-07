using System;
using System.IO;
using Xamarin.Forms;
using GrocerEase.Droid;

[assembly: Dependency(typeof(Helper))]
namespace GrocerEase.Droid
{
    public class Helper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}