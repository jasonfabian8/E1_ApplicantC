using ApplicantC.Data;
using ApplicantC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Data.Entity.ModelConfiguration.Configuration;

namespace ApplicantC.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Models.Movie> GetList(string title, int genre, Order? order)
        {
            /*    Deberá mostrar solamente los campos imagen, título y fecha de creación.
El endpoint deberá ser:
● GET /movies
            */

            /*

    Deberá permitir buscar por título, y filtrar por género. Además, permitir ordenar los resultados por fecha
de creación de forma ascendiente o descendiente.
El término de búsqueda, filtro u ordenación se deberán especificar como parámetros de query:
● /movies?name=nombre
● /movies?genre=idGenero
● /movies?order=ASC | DESC


            */

            ChallengeContext db = new ChallengeContext();
            var list = from b in db.Movies
                       where ((title == null) || (b.Title.Contains(title)))
                            && ((genre == 0) || (b.Genre.Id == genre))
                       select new Models.Movie { Id = b.Id, Title = b.Title, Image = b.Image, 
                          CreatedDate = b.CreatedDate 
                       };
            return (order==null) ? list : (order==Order.ASC) ? list.OrderBy(x=>x.CreatedDate) : list.OrderByDescending(x => x.CreatedDate);

        }

        [HttpGet]
        [Route("{id}")]

        public Models.MovieDetail GetDetail(int id)
        {
            /*
                  En el detalle deberán listarse todos los atributos del personaje, como así también sus películas o series
relacionadas
*/
            ChallengeContext db = new ChallengeContext();
            Data.Movie m = db.Movies.Find(id);
            if (m == null) return null;
            Models.MovieDetail md = new Models.MovieDetail
            {
                Id = m.Id,
                Title = m.Title,
                Image = m.Image,
                CreatedDate = m.CreatedDate,
                Rating=m.Rating,
                GenreId=m.GenreId
            };
            var list = from c in m.Characters
                       select new Models.Character
                       {
                           Id = c.Id,
                           Image = c.Image,
                           Name = c.Name
                       };
            md.Characters = list.ToArray();
            return md;
        }

        [HttpPost]
        public IActionResult Post(Models.MovieDetail movie)
        {
            ChallengeContext db = new ChallengeContext();
            Data.Genre g = db.Genres.Find(movie.GenreId);
            if (g == null) return BadRequest();
            Data.Movie m = new Data.Movie
            {
                Title = movie.Title,
                Image = movie.Image,
                CreatedDate= movie.CreatedDate,
                Rating = movie.Rating,
                //GenreId = movie.GenreId
                Genre = db.Genres.Find(movie.GenreId)
            };
            if (movie.Characters != null)
                foreach (Models.Character c in movie.Characters)
                {
                    Data.Character ch = db.Characters.Find(c.Id);
                    if (ch != null) m.Characters.Add(ch);
                }
            db.Movies.Add(m);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Models.MovieDetail movie)
        {
            ChallengeContext db = new ChallengeContext();
            Data.Movie m = db.Movies.Find(movie.Id);
            if (m != null) 
            {
                m.Title = movie.Title;
                m.Image = movie.Image;
                m.CreatedDate = movie.CreatedDate;
                m.Rating = movie.Rating;
                m.GenreId = movie.GenreId;
                m.Characters.Clear();
                if (movie.Characters != null)
                    foreach (Models.Character c in movie.Characters)
                    {
                        Data.Character ch = db.Characters.Find(c.Id);
                        if (ch != null) m.Characters.Add(ch);
                    }

                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            ChallengeContext db = new ChallengeContext();
            Data.Movie m = db.Movies.Find(id);
            if (m != null)
            {
                db.Movies.Remove(m);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
    }

    /*
 

    Devolverá todos los campos de la película o serie junto a los personajes asociados a la misma

    Deberán existir las operaciones básicas de creación, edición y eliminación de películas o series.

    */
}
