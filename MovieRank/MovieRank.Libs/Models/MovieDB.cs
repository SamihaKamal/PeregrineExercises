using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Libs.Models
{
    [DynamoDBTable("MovieRank")]
    public class MovieDB
    {
        [DynamoDBHashKey]
        public int UserId { get; set; }
        public string MovieName { get; set; }
        [DynamoDBGlobalSecondaryIndexHashKey]
        public string Description { get; set; }
        public List<string> Actors { get; set; }
        public int Ranking { get; set; }
        public string RankedDateTime { get; set; }

    }
}
