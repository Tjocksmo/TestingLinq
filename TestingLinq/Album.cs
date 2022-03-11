using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLinq
{
    class Album
    {
        public string Title { get; set; }
        public Artist Artist { get; set; }
        public List<Track> Tracks { get; set; } = new List<Track>();
        public DateTime ReleaseDate { get; set; }
        public override string ToString()
        {
            string sRet = "";
            sRet += $"      - Album: {Title}. Date: {ReleaseDate}.\n";
            foreach (var track in Tracks)
            {
                sRet += track.ToString();
            }
            return sRet;
        }
        
    }
}
