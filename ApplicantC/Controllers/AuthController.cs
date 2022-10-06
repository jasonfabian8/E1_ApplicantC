using ApplicantC.Data;
using ApplicantC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ApplicantC.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]

        public IActionResult Login([FromBody] Models.UserInfo user)
        {
            ChallengeContext db = new ChallengeContext();
            if (db.Users.Where(u => u.Username == user.Username && u.Password == user.PasswordHash).FirstOrDefault() == null)
                return BadRequest("Credenciales incorrectas");
            else
                return BuildToken(user);

        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] Models.UserInfo user)
        {
            ChallengeContext db = new ChallengeContext();
            if (db.Users.Find(user.Username) != null) return BadRequest("Usuario existente");
            if (!IsValid(user.Username)) return BadRequest("email incorrecto");
            Data.User u = new User()
            {
                Username = user.Username,
                Password = user.PasswordHash
                };
            db.Users.Add(u);
            db.SaveChanges();
            return Ok();
        }

        private static bool IsValid(string email)
        {
            var valid = true;
            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        private IActionResult BuildToken(UserInfo user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //Id único por cada registro de usuario
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["PrivateKeyJWT"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "local",
                audience: "local",
                claims: claims,
                expires: expiration,
                signingCredentials: creds
                );

            return Ok(new { 
                token = new JwtSecurityTokenHandler().WriteToken(token),  expiration=expiration
            });   
        }
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
