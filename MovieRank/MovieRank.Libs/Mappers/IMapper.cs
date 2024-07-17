using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using MovieRank.Contracts;
using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Libs.Mappers
{
    public interface IMapper
    {
        IEnumerable<MovieResponse> ToMovieContract(ScanResponse response);
        MovieResponse ToMovieContract(GetItemResponse response);
        IEnumerable<MovieResponse> ToMovieContract(QueryResponse response);
    }
}
