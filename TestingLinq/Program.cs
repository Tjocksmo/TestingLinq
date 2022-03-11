using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Artist> artists = new List<Artist>();
            for (int i = 0; i < 10; i++)
            {
                artists.Add(ArtistSeed());
            }
            artists.ForEach(x => Console.WriteLine(x));

            List<string> artistWithFirstName = artists.OrderBy(o => o.FirstName)
                                                      .ThenBy(s => s.LastName)
                                                      .Select(a => $"{a.FirstName} {a.LastName} from {a.FromCountry}")
                                                      .Distinct()
                                                      .ToList();
            artistWithFirstName.ForEach(f => Console.WriteLine(f));
            Console.WriteLine();
            artistWithFirstName.Reverse();
            artistWithFirstName.ForEach(f => Console.WriteLine(f));

            Console.WriteLine();
            List<Artist> artistFromCountry = artists.Where(c => c.FromCountry == "Uzbekistan").ToList();
            Console.WriteLine();
            artistFromCountry.ForEach(c => Console.WriteLine($"{c.FirstName} {c.LastName} {c.FromCountry}"));
            Console.WriteLine();

            artistWithFirstName = artists.Select(a => $"{a.FirstName} {a.LastName} from {a.FromCountry}")
                                         .Distinct()
                                         .ToList();
            artistWithFirstName.ForEach(f => Console.WriteLine(f));
            Console.WriteLine();
            artistWithFirstName.Reverse();
            artistWithFirstName.ForEach(f => Console.WriteLine(f));

            Console.WriteLine();
            artistWithFirstName.Take(3).Reverse().ToList().ForEach(t => Console.WriteLine(t));
            Console.WriteLine();

            artistWithFirstName.Take(10).Skip(7).Reverse().ToList().ForEach(t => Console.WriteLine(t));
            Console.WriteLine();
        }
        public static Artist ArtistSeed()
        {
            Artist artist = new Artist();
            var rnd = new Random();
            string[] firstNames = "Bob,Eric,John,Patrik,Anton,Emil,Andreas,Cicci".Split(',');
            string[] lastNames = "Marley,Clapton,Fogerty,Persson,Thunman Jonsson,Magnusson,Brullo,Nyberg".Split(',');
            string[] country = "Jamaica,USA,Sweden,UK,Finland,Uzbekistan,India".Split(',');

            artist.FirstName = firstNames[rnd.Next(0, firstNames.Length)];
            artist.LastName = lastNames[rnd.Next(0, lastNames.Length)];
            artist.FromCountry = country[rnd.Next(0, country.Length)];

            for (int i = 0; i < rnd.Next(1, 15); i++)
            {
                artist.Albums.Add(AlbumSeed(artist));
            }
            return artist;
        }
        public static Album AlbumSeed(Artist artist)
        {
            Album album = new Album();
            var rnd = new Random();
            int year = rnd.Next(1955, 2020);

            string[] title = "Exodus,Pink flowers in may,Enigma,Bluberries from hell,Bluberry Hill,Sailing the seas of cheese".Split(',');
            album.ReleaseDate = new DateTime(year, 1, 1);
            album.Artist = artist;
            album.Title = title[rnd.Next(0, title.Length)];

            for (int i = 0; i < rnd.Next(1, 15); i++)
            {
                album.Tracks.Add(TracksSeed(album));
            }

            return album;
        }
        public static Track TracksSeed(Album album)
        {
            Track track = new Track();
            var rnd = new Random();
            string[] songTitle = "Fling my flong,What the heck,The poo from hell,Dinga linga Lena,Proud Mary,Down on the corner,Up the hill,Beside me".Split(',');
            track.Album = album;
            track.Title = songTitle[rnd.Next(0, songTitle.Length)];
            track.SongLength = new TimeSpan(0,rnd.Next(1, 7), rnd.Next(0, 60));
            
            return track;
        }
    }
}
