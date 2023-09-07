using Movie.BL.Model;

namespace Movie.BL.Interfaces
{
    public interface IGeners
    {
        public Task<IEnumerable<GenersVM>> GetGeners();
    }
}
