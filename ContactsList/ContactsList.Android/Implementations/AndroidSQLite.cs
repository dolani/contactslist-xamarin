using SQLite;
using System.IO;
using ContactsList.Helpers;
using ContactsList.Droid.Implementations;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLite))]
namespace ContactsList.Droid.Implementations
{
    public class AndroidSQLite : ISQLite
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