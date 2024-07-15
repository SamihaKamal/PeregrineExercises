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
        IEnumerable<MovieResponse> ToMovieContract(IEnumerable<MovieDB> items);
        MovieResponse ToMovieContract(MovieDB movie);
        MovieDB ToMovieDbModel(int userId, MovieRankRequest movieRankRequest);
    }
}
