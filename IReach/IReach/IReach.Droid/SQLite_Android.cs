using System;
using System.IO;
using IReach;
using IReach.Droid;
using IReach.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace IReach
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android ( ) { }

        public global::SQLite.SQLiteConnection GetConnection ( )
        {
            var sqliteFilename = "FoodSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath ( System.Environment.SpecialFolder.Personal ); // Documents folder
            var path = Path.Combine ( documentsPath, sqliteFilename );

            // This is where we copy in the prepopulated database
            Console.WriteLine ( path );
            if ( !File.Exists ( path ) )
            {
                var s = Forms.Context.Resources.OpenRawResource ( Resource.Raw.FoodSQLite );  // RESOURCE NAME ###

                // create a write stream
                FileStream writeStream = new FileStream ( path, FileMode.OpenOrCreate, FileAccess.Write );
                // write to the stream
                ReadWriteStream ( s, writeStream );
            }

            var conn = new global::SQLite.SQLiteConnection ( path );

            // Return the database connection 
            return conn;
        }
        void ReadWriteStream ( Stream readStream, Stream writeStream )
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