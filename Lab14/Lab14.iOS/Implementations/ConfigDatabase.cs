using Foundation;
using Lab14.Interface;
using Lab14.iOS.Implementations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConfigDatabase))]
namespace Lab14.iOS.Implementations
{
    class ConfigDatabase : IConfigDataBase
    {
        public string GetFullPath(string databaseFileName)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), databaseFileName);
        }
    }
}