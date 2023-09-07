using Movie.BL.Model;

namespace Movie.BL.Interfaces
{
    public interface IMovies
    {
        public Task<IEnumerable<MoviesVM>> GetMovies();
        public Task UpdateMovies(MoviesVM model);
        public Task CreateMovies(MoviesVM model);
        public Task DeleteMovies(int id);
        public Task<MoviesVM> GetMoviesById(int id);

    }
}
