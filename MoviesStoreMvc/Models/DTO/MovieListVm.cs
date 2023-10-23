using MoviesStoreMvc.Models.Domain;

namespace MoviesStoreMvc.Models.DTO
{
    public class MovieListVm
    {
        public IQueryable<Movie> MovieList { get; set; }

    }
}
