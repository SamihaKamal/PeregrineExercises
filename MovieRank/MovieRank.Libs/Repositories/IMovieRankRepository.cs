using MovieRank.Libs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRank.Libs.Repositories
{
    public interface IMovieRankRepository
    {
        Task<IEnumerable<MovieDB>> GetAllItems();
        Task<MovieDB> GetMovie(int userId, string movieName);
        Task<IEnumerable<MovieDB>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName);
        Task AddMovie(MovieDB movieDb);
    }
}
