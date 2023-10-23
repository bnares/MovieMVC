using Microsoft.AspNetCore.Mvc;
using MoviesStoreMvc.Models.Domain;
using MoviesStoreMvc.Repositories.Abstract;

namespace MoviesStoreMvc.Repositories.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly DatabaseContext _context;
        public GenreService(DatabaseContext context)
        {
            _context = context;
        }

        public bool Add(Genre model)
        {
            try
            {
                _context.Genre.Add(model);
                _context.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = this.GetById(id);
                if(entity == null)
                {
                    return false;
                }
                _context.Genre.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Genre? GetById(int id)
        {
            var entity = _context.Genre.FirstOrDefault(x=>x.Id== id);
            return entity;
        }

        public IQueryable<Genre> List()
        {
            var data = _context.Genre.AsQueryable();
            return data;
        }

        public bool Update(Genre model)
        {
            try
            {
                _context.Genre.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
