using Microsoft.AspNetCore.Mvc;

namespace ApplicantC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
    }

    /*
     Deberá mostrar solamente los campos imagen, título y fecha de creación.
El endpoint deberá ser:
● GET /movies

    Devolverá todos los campos de la película o serie junto a los personajes asociados a la misma

    Deberán existir las operaciones básicas de creación, edición y eliminación de películas o series.

    Deberá permitir buscar por título, y filtrar por género. Además, permitir ordenar los resultados por fecha
de creación de forma ascendiente o descendiente.
El término de búsqueda, filtro u ordenación se deberán especificar como parámetros de query:
● /movies?name=nombre
● /movies?genre=idGenero
● /movies?order=ASC | DESC

    */
}
