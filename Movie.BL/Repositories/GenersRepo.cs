using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Movie.BL.Interfaces;
using Movie.BL.Model;
using Movie.DAL.Database;

namespace Movie.BL.Repositories
{
    public class GenersRepo : IGeners
    {
        #region Properties
        private readonly ApllicationDbContext dbContext;
        private readonly IMapper mapper;
        #endregion

        #region Ctor
        public GenersRepo(ApllicationDbContext dbContext , IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<GenersVM>> GetGeners()
        {
            var items = await dbContext.Geners.ToListAsync();
            var data = mapper.Map<IEnumerable<GenersVM>>(items);
            return data;
        }
        #endregion
    }
}
