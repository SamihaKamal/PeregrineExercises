using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Contracts
{
    public class MovieUpdateRequest
    {
        public string MovieName { get; set; }
        public int Ranking { get; set; }
    }
}
