using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Contracts
{
    public class MovieRankRequest
    {
        public string MovieName { get; set; }
        public string Description { get; set; }
        public List<String> Actors { get; set; }
        public int Ranking { get; set; }
        
    }
}
