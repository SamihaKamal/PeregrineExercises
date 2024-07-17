using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Contracts
{
    public class MovieRankResponse
    {
        public string MovieName { get; set; }
        public double overally { get; set; }
    }
}
