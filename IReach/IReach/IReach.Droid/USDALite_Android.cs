using System;
using System.IO;
using IReach;
using IReach.Droid;
using IReach.Services; 
using Xamarin.Forms;

[assembly: Dependency(typeof(USDALite_Android))]
namespace IReach
{
    public class USDALite_Android : IUsda
    {
        public USDALite_Android ( ) { }
        public global::SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "usda_food.sqlite3";

            string documentPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFilename);

            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                var s = Forms.Context.Resources.OpenRawResource(Resource.Raw.usda_food);
                FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);

                ReadWriteStream(s, writeStream);
            }

            var conn = new SQLite.SQLiteConnection(path);

            return conn;
        }

        private void ReadWriteStream(Stream readStream, FileStream writeStream)
        {

            int Length = 256;
            Byte[ ] buffer = new Byte[ Length ];
            int bytesRead = readStream.Read ( buffer, 0, Length );
            // write the required bytes
            while ( bytesRead > 0 )
            {
                writeStream.Write ( buffer, 0, bytesRead );
                bytesRead = readStream.Read ( buffer, 0, Length );
            }
            readStream.Close ( );
            writeStream.Close ( );
        }
    }
}