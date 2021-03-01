using Lab.Model;
using System;
using System.Linq;
using System.Text;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SoftUni;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -o Models - f - d

            Console.OutputEncoding = Encoding.Unicode; // конзолата да дава кирилица !!!

            var db = new MusicXContext();
            // Console.WriteLine(db.Songs.Count());

            // по дефолт се взимат само примитивните типове от данни !!!


            // WHERE
            //var songs = db.Songs.Where(x => x.Name.StartsWith("Н")).ToList();
            //Console.WriteLine(songs.Count());

            //var songs = db.Songs.Where(x => x.Source.Name == "User").ToList();
            //foreach (var song in songs)
            //{
            //    Console.WriteLine(song.Name);
            //}


            // SELECT

            var songs = db.Songs.Where(x => x.Source.Name == "User")
                .Select(x => new
                { 
                x.Name,
                Source = x.Source.Name,
                Artists = string.Join(", ", x.SongArtists.Select(a => a.Artist.Name)),
                })
                .ToList();

            foreach (var song in songs)
            {
                Console.WriteLine(song.Artists + " - " + song.Name);
            }

            // WITH .SELECT() => anonymous type
            // 1. (+) Navigational properties in the lambda expression
            // 2. (+) Get only the columns we need
            // 3. (-) No update/delete


            // NO .SELECT(): => original entity
            // 1. (-)No Access to navigational properties
            // 2. (-)Get All colums for entity
            // 3. (+) update/delete intity / SaveChanges()

            // anonymous type не се траква change tracker-a (savechanges!)

             
        }
    }
}
