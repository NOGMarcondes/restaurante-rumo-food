using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Models;
using RestauranteAPI.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UsuarioController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]

        public IActionResult create(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login(Usuario usuario)
        {
            var user = _context.Usuarios
                .FirstOrDefault(u => u.email == usuario.email
                                  && u.senha == usuario.senha);

            if (user == null)
                return NotFound("Usuário ou senha inválidos");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(ClaimTypes.Name, user.name),
        new Claim(ClaimTypes.Role, user.perfil)
    };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddHours(8),
                signingCredentials: credentials
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Id == id);

            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return Ok();
        }

    }
}
