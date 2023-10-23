using Microsoft.EntityFrameworkCore;
using MoviesStoreMvc.Models.Domain;
using MoviesStoreMvc.Models.DTO;
using MoviesStoreMvc.Repositories.Abstract;

namespace MoviesStoreMvc.Repositories.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly DatabaseContext _context;
        public MovieService(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public bool Add(Movie model)
        {
            try
            {
                _context.Movie.Add(model);
                _context.SaveChanges();
                foreach (var genreId in model.Genres)
                {
                    var movieGenre = new MovieGenre
                    {
                        MovieId = model.Id,
                        GenreId = genreId
                    };
                    _context.MovieGenre.Add(movieGenre);

                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = this.GetById(id);
                if (entity == null)
                {
                    return false;
                }
                var movieGenres = _context.MovieGenre.Where(a => a.MovieId == entity.Id);
                foreach(var item in movieGenres)
                {
                    _context.MovieGenre.Remove(item);
                }
                _context.Movie.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Movie GetById(int id)
        {
            var entity = _context.Movie.FirstOrDefault(x => x.Id == id);
            return entity;
        }

        public MovieListVm List()
        {
            var list = _context.Movie.ToList();
            foreach(var movie in list)
            {
                var genres = (from genre in _context.Genre join mg in _context.MovieGenre
                              on genre.Id equals mg.GenreId where mg.MovieId == movie.Id
                              select genre.GenreName).ToList();
                var genreNames = string.Join(',', genres);
                movie.GenreNames = genreNames;
            }
            var data = new MovieListVm()
            {
                MovieList = list.AsQueryable()
            };
            return data;
        }

        public bool Update(Movie model)
        {
            try
            {
                _context.Movie.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> GetGenreByMovieId(int movieId)
        {
            var genreIds = _context.MovieGenre.Where(a=>a.MovieId==movieId)
                .Select(a=>a.GenreId).ToList();
            return genreIds;
        }
    }
}
