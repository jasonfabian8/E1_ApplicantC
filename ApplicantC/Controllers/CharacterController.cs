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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApplicantC.Controllers
{
    [ApiController]
    [Route("characters")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CharacterController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<Models.Character> GetList(string name, int age, int weight, int idMovie)
        {
            /*El listado deberá mostrar:
                ● Imagen.
                ● Nombre.
                El endpoint deberá ser: /characters
            */

/*
Deberá permitir buscar por nombre, y filtrar por edad, peso o películas/series en las que participó.
Para especificar el término de búsqueda o filtros se deberán enviar como parámetros de query:
● GET /characters?name=nombre
● GET /characters?age=edad
● GET /characters?movies=idMovie

*/

            ChallengeContext db = new ChallengeContext();
            var list = from b in db.Characters
                       where ((name == null) || (b.Name.Contains(name)))
                            && ((age == 0) || (b.Age == age))
                            && ((weight == 0) || (b.Weight == weight))
                            && ((idMovie == 0) || (b.Movies.Where(m=>m.Id==idMovie).Count()>0))
                       select new Models.Character
                        {
                            Id = b.Id,
                            Name = b.Name,
                            Image = b.Image
                        };
            return list;
            
        }

        [HttpGet]
        [Route("{id}")]

        public Models.CharacterDetail GetDetail(int id)
        {
            /*
                  En el detalle deberán listarse todos los atributos del personaje, como así también sus películas o series
relacionadas
*/
            ChallengeContext db = new ChallengeContext();
            Data.Character c = db.Characters.Find(id);
            if (c == null) return null;
            Models.CharacterDetail cd = new Models.CharacterDetail
            {
                Id = c.Id,
                Name = c.Name,
                Image = c.Image,
                Age = c.Age,
                Weight = c.Weight,
                Story = c.Story
            };
            var list = from m in c.Movies
                       select new Models.Movie
                       {
                           Id = m.Id,
                           Image = m.Image,
                           Title = m.Title, 
                           CreatedDate = m.CreatedDate
                       };
            cd.Movies = list.ToArray();
            return cd;
        }

        [HttpPost]
        public IActionResult Post(Models.CharacterDetail character)
        {
            ChallengeContext db = new ChallengeContext();
            Data.Character c = new Data.Character
            {
                Name = character.Name,
                Image = character.Image,
                Age = character.Age,
                Weight = character.Weight,
                Story = character.Story
            };
            if (character.Movies != null)
                foreach (Models.Movie m in character.Movies)
                {
                    Data.Movie mo = db.Movies.Find(m.Id);
                    if (mo != null) c.Movies.Add(mo);
                }
            db.Characters.Add(c);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Models.CharacterDetail character)
        {
            ChallengeContext db = new ChallengeContext();
            Data.Character c = db.Characters.Find(character.Id);
            if (c != null)
            {
                c.Name = character.Name;
                c.Image = character.Image;
                c.Age = character.Age;
                c.Weight = character.Weight;
                c.Story = character.Story;
                c.Movies.Clear();
                if (character.Movies != null)
                    foreach (Models.Movie m in character.Movies)
                    {
                        Data.Movie mo = db.Movies.Find(m.Id);
                        if (mo != null) c.Movies.Add(mo);
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
            Data.Character c = db.Characters.Find(id);
            if (c != null)
            {
                db.Characters.Remove(c);
                db.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

    }
        }
