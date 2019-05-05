using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ContactsList.Helpers;
using ContactsList.iOS.Implementations;
using Foundation;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(iOSSQLite))]
namespace ContactsList.iOS.Implementations
{
    public class iOSSQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {

            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            // Documents folder  
            var path = Path.Combine(documentsPath, DatabaseHelper.DbFileName);
            var conn = new SQLiteConnection(path);

            // Return the database connection  
            return conn;
        }
    }
}