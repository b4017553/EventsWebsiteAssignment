using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventsWebsite.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace EventsWebsite.Controllers
{
    [Authorize(Roles = "Manager")]
    public class CMSController : Controller
    {
        private readonly ILogger<CMSController> _logger;
        ApplicationDbContext _context;

        public CMSController(ILogger<CMSController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        

        public IActionResult Index()
        {
            List<Movie> model = _context.Movies.ToList();
            
            return View(model);
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            List<Movie> model = _context.Movies.ToList();

            List<string> genres = new List<string>();

            foreach (var item in model)
            {
                List<string> temp = new List<string>();
                temp = (item.Genres.Split(',').ToList());
                foreach (var tempi in temp)
                {
                    if (!genres.Contains(tempi) || genres.Count == 0)
                    {
                        genres.Add(tempi);
                    }
                }
            }

            List<string> uniqueList = new List<string>();

            for (int i = 0; i < genres.Count(); i++)
            {
                bool duplicate = false;
                for (int z = 0; z < i; z++)
                {
                    string temp1 = genres[z];
                    string temp2 = genres[i];

                    genres[z] = temp1.Trim();
                    genres[i] = temp2.Trim();

                    if (genres[z].StartsWith(genres[i]))
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (!duplicate)
                {
                    uniqueList.Add(genres[i]);
                }
            }

            ViewBag.Genres = uniqueList;
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieForm model)
        {
            if (ModelState.IsValid)
            {
                Movie newMovie = new Movie
                {
                    MovieTitle = model.MovieTitle,
                    MovieCertificate = model.MovieCertificate,
                    MovieDescription = model.MovieDescription,
                    MovieImage = model.MovieImage,
                    MoviePrice = model.MoviePrice,
                    IMDbRating = model.IMDbRating,
                    ReleaseDate = DateTime.Now,
                    RunTime = model.RunTime,
                    Created = DateTime.Now,
                    Modified = model.Modified,
                    Year = DateTime.Now.Year,
                    Genres = model.Genres,
                    NumVotesIMDb = model.NumVotesIMDb,
                    Directors = model.Directors,
                    URL = model.URL,
                };
                _context.Add(newMovie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            } 

            return View();

        }

        [HttpGet]
        public IActionResult UpdateMovie(int id)
        {
            Movie model = _context.Movies.Find(id);
            MovieForm formModel = new MovieForm
            {
                MovieID = model.MovieID,
                MovieTitle = model.MovieTitle,
                MovieCertificate = model.MovieCertificate,
                MovieDescription = model.MovieDescription,
                MovieImage = model.MovieImage,
                MoviePrice = model.MoviePrice,
                IMDbRating = model.IMDbRating,
                ReleaseDate = DateTime.Now,
                RunTime = model.RunTime,
                Created = DateTime.Now,
                Modified = model.Modified,
                Year = DateTime.Now.Year,
                Genres = model.Genres,
                NumVotesIMDb = model.NumVotesIMDb,
                Directors = model.Directors,
                URL = model.URL,
            };
            ViewBag.ImageName = model.MovieImage;
            return View(formModel);
        }

        [HttpPost]
        public IActionResult UpdateMovie(MovieForm model)
        {
            if (ModelState.IsValid)
            {
                Movie editMovie = new Movie
                {
                    MovieID = model.MovieID,
                    MovieTitle = model.MovieTitle,
                    MovieCertificate = model.MovieCertificate,
                    MovieDescription = model.MovieDescription,
                    MovieImage = model.MovieImage,
                    MoviePrice = model.MoviePrice,
                    IMDbRating = model.IMDbRating,
                    ReleaseDate = DateTime.Now,
                    RunTime = model.RunTime,
                    Created = DateTime.Now,
                    Modified = model.Modified,
                    Year = DateTime.Now.Year,
                    Genres = model.Genres,
                    NumVotesIMDb = model.NumVotesIMDb,
                    Directors = model.Directors,
                    URL = model.URL,
                };
                _context.Movies.Update(editMovie);

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult DeleteMovie(int Id)
        {
            Movie model = _context.Movies.Find(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteMovie(Movie model)
        {
            _context.Movies.Remove(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
