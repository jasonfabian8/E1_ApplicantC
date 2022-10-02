using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace ApplicantC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
    }

    /*
    Para realizar peticiones a los endpoints subsiguientes el usuario deberá contar con un token que
    obtendrá al autenticarse. Para ello, deberán desarrollarse los endpoints de registro y login, que
    permitan obtener el token.
    Los endpoints encargados de la autenticación deberán ser:
    ● / auth / login
    ● / auth / register

    Al registrarse en el sitio, el usuario deberá recibir un email de bienvenida. Es recomendable, la
utilización de algún servicio de terceros como SendGrid.
         */

}
