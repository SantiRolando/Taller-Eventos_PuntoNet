Controllers/AccountController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Eventos_PuntoNet.Components.Data;
using Eventos_PuntoNet.Components.Models;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly IDbContextFactory<AppDbContext> _dbFactory;
    public AccountController(IDbContextFactory<AppDbContext> dbFactory) => _dbFactory = dbFactory;

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        using var ctx = _dbFactory.CreateDbContext();
        var user = await ctx.Usuarios.FirstOrDefaultAsync(u => u.Email == dto.Email && u.Password == dto.Password);
        if (user is null) return Unauthorized("Credenciales inválidas");

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Ci),
            new Claim(ClaimTypes.Name, user.Nombre),
            new Claim("TipoUsuario", user.TipoUsuario)
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        return Ok();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok();
    }
}

public record LoginDto(string Email, string Password);