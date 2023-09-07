using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie.BL.Interfaces;
using Movie.BL.Model;
using Movie.DAL.Database;
using Movie.DAL.Entity;

namespace Movie.BL.Repositories
{
    public class MoviesRepo : IMovies
    {

        #region Properties
        private readonly ApllicationDbContext dbContext;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public MoviesRepo(ApllicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task CreateMovies(MoviesVM model)
        {
            var item = mapper.Map<Movies>(model);
            await dbContext.Movies.AddAsync(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteMovies(int id)
        {
            var item = await dbContext.Movies.FindAsync(id);
            dbContext.Movies.Remove(item);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<MoviesVM>> GetMovies()
        {
            var item = await dbContext.Movies.ToListAsync();
            var data = mapper.Map<IEnumerable<MoviesVM>>(item);
            return data;
        }

        public async Task UpdateMovies(MoviesVM model)
        {
            var item = mapper.Map<Movies>(model);
            dbContext.Entry(item).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public async Task<MoviesVM> GetMoviesById(int id)
        {
            var item = await dbContext.Movies.FindAsync(id);
            var data = mapper.Map<MoviesVM>(item);
            return data;
        }
        #endregion

    }
}
