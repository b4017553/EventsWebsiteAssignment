using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EventsWebsite.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventsWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Movies()
        { 
            List<Movie> model = _context.Movies.ToList();
            return View(model);
        }

        public IActionResult EditMovies()
        {
            List<Movie> model = _context.Movies.ToList();
            return View(model);
        }


        public IActionResult OneMovie()

        {
            Movie model = _context.Movies.FirstOrDefault();

            return View(model);

        }

        public IActionResult MovieDetails(int id)

        {

            Movie model = _context.Movies.Find(id);

            return View(model);

        }

        public IActionResult Search(String SearchString, String MovCert)

        {
            List<Certifications> ListCerts = new List<Certifications>();
            if(ListCerts.Count == 0)
            {
                ListCerts.Add(new Certifications { Text = "All", Value = "All" });
            }

            foreach (var item in _context.Movies)
            {
                    ListCerts.Add(new Certifications { Text = item.MovieCertificate, Value = item.MovieCertificate });
            }

            List<Certifications> uniqueList = new List<Certifications>();

            for (int i = 0; i < ListCerts.Count(); i++)
            {
                bool duplicate = false;
                for (int z = 0; z < i; z++)
                {
                    if (ListCerts[z].Text == ListCerts[i].Text)
                    {
                        duplicate = true;
                        break;
                    }
                }
                if(!duplicate)
                {
                    uniqueList.Add(ListCerts[i]);
                }
            }

           
            ViewBag.Cert = uniqueList;
            if (!string.IsNullOrEmpty(SearchString) && MovCert == "All")
            {
                var movies = from m in _context.Movies

                             where m.MovieTitle.StartsWith(SearchString)

                             select m;

                List<Movie> model = movies.ToList();

                ViewData["SearchString"] = SearchString;
                ViewData["MovCert"] = MovCert;

                return View(model);
            }
            else if (!string.IsNullOrEmpty(SearchString) && !string.IsNullOrEmpty(MovCert))
            {
                var movies = from m in _context.Movies

                             where m.MovieTitle.StartsWith(SearchString)

                             where m.MovieCertificate.Contains(MovCert)

                             select m;

                List<Movie> model = movies.ToList();

                ViewData["SearchString"] = SearchString;
                ViewData["MovCert"] = MovCert;

                return View(model);
            }
            else if (!string.IsNullOrEmpty(SearchString))
            {

                var movies = from m in _context.Movies

                             where m.MovieTitle.StartsWith(SearchString)

                             select m;

                List < Movie > model = movies.ToList();
              
                ViewData["SearchString"] = SearchString;

                return View(model);

            }
            else if(!string.IsNullOrEmpty(MovCert))
            {
                
                if (MovCert == "All")
                {
                    var movies = _context.Movies;
                    List<Movie> model = movies.ToList();
                    ViewData["MovCert"] = MovCert;
                    return View(model);
                }
                else
                {
                    var movies = from m in _context.Movies

                                 where m.MovieCertificate.Contains(MovCert)

                                 select m;
                    List<Movie> model = movies.ToList();
                    ViewData["MovCert"] = MovCert;
                    return View(model);
                }
                         
            }
            else
            {
                var movies = _context.Movies;
                List<Movie> model = movies.ToList();
                
                return View(model);
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
