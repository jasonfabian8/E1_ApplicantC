using ApplicantC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicantC.Controllers
{
    [ApiController]
    [Route("characters")]
    public class CharacterController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<object> GetList()
        {
            /*El listado deberá mostrar:
                ● Imagen.
                ● Nombre.
                El endpoint deberá ser: /characters
            */
            return MOCAP.GetListCharacter();
        }

        [HttpPost]
        public IActionResult Post(Character character)
        {
            MOCAP.ListCharacters.Add(character);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(Character character)
        {
            Character character1 = MOCAP.ListCharacters.Where(c => character.Name == c.Name).FirstOrDefault();
            if (character1 != null)
            {
                character1.Image = character.Image;
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(Character character)
        {
            Character characterDelete = MOCAP.ListCharacters.Where(c => character.Name == c.Name).FirstOrDefault();
            if (characterDelete != null)
            {
                MOCAP.ListCharacters.Remove(characterDelete);
                return Ok();
            }
            return BadRequest();
        }



    }
    /*
    Deberán existir las operaciones básicas de creación, edición y eliminación de personajes

    En el detalle deberán listarse todos los atributos del personaje, como así también sus películas o series
relacionadas

    Deberá permitir buscar por nombre, y filtrar por edad, peso o películas/series en las que participó.
Para especificar el término de búsqueda o filtros se deberán enviar como parámetros de query:
● GET /characters?name=nombre
● GET /characters?age=edad
● GET /characters?movies=idMovie

*/
}
