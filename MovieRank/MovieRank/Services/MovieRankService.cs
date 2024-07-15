﻿using MovieRank.Contracts;
using MovieRank.Libs.Mappers;
using MovieRank.Libs.Repositories;

namespace MovieRank.Services
{
    public class MovieRankService : IMovieRankService
    {
        private readonly IMovieRankRepository _movieRankRepository;
        private readonly IMapper _map;

        public MovieRankService(IMovieRankRepository movieRankRepository, IMapper map)
        {
            _movieRankRepository = movieRankRepository;
            _map = map;
        }

        public async Task<IEnumerable<MovieResponse>> GetAllItemsFromDatabase()
        {
            var response = await _movieRankRepository.GetAllItems();

            return _map.ToMovieContract(response);
        }

        public async Task<MovieResponse> GetMovie(int userId, string movieName)
        {
            var response = await _movieRankRepository.GetMovie(userId, movieName);

            return _map.ToMovieContract(response);
        }

        public async Task<IEnumerable<MovieResponse>> GetUsersRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var response = await _movieRankRepository.GetUsersRankedMoviesByMovieTitle(userId, movieName);

            return _map.ToMovieContract(response);
        }

        public async Task AddMovie(int userId, MovieRankRequest movieRankRequest)
        {
            var movieDb = _map.ToMovieDbModel(userId, movieRankRequest);

            await _movieRankRepository.AddMovie(movieDb);
        }
    }
}
