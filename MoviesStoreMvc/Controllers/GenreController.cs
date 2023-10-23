﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesStoreMvc.Models.Domain;
using MoviesStoreMvc.Repositories.Abstract;

namespace MoviesStoreMvc.Controllers
{
   // [Authorize(Roles ="Admin")]
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Genre model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _genreService.Add(model);
            if (result)
            {
                TempData["msg"] = "Successfully Added";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on Server site";
                return View();
            }
            
        }

        public IActionResult Edit(int id)
        {
            var data = _genreService.GetById(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _genreService.Update(model);
            if (result)
            {
                TempData["msg"] = "Successfully Added";
                return RedirectToAction(nameof(GenreList));
            }
            else
            {
                TempData["msg"] = "Error on Server site";
                return View(model);
            }

        }

        public IActionResult GenreList()
        {
            var data = _genreService.List().ToList();
            return View(data);
        }

        
        public IActionResult Delete(int id)
        {
            var result = _genreService.Delete(id);
            return RedirectToAction(nameof(GenreList));

        }
    }
}
