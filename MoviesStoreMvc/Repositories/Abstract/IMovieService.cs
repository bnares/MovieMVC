using MoviesStoreMvc.Models.Domain;
using MoviesStoreMvc.Models.DTO;

namespace MoviesStoreMvc.Repositories.Abstract
{
    public interface IMovieService
    {
        bool Add(Movie model);
        bool Update(Movie model);
        Movie GetById(int id);
        bool Delete(int id);
        MovieListVm List();
        public List<int> GetGenreByMovieId(int movieId);
    }
}
