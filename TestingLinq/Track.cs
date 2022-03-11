using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingLinq
{
    class Track
    {
        public string Title { get; set; }
        public Album Album { get; set; }
        public TimeSpan SongLength { get; set; }
        public override string ToString() => $"         - Title: {Title,-30} Duration: {SongLength}\n";        
    }
}
