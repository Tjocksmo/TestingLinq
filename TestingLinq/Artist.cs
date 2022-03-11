using System.Collections.Generic;

namespace TestingLinq
{
    class Artist
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FromCountry { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();
        public override string ToString()
        {
            string sRet = "";
            sRet += $"  - Artist: {FirstName} {LastName} from country {FromCountry}\n";

            foreach (var album in Albums)
            {
                sRet += album.ToString();
            }            
            return sRet;
        }
    }
}
