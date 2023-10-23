using MoviesStoreMvc.Models.Domain;
using MoviesStoreMvc.Models.DTO;

namespace MoviesStoreMvc.Repositories.Abstract
{
    public interface IGenreService
    {
        bool Add(Genre model);
        bool Update(Genre model);
        Genre GetById(int id);
        bool Delete(int id);
        IQueryable<Genre> List();
    }
}
