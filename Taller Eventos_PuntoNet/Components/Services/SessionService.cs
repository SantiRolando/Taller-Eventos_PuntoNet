using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Threading.Tasks;
using Eventos_PuntoNet.Components.Models;

namespace Eventos_PuntoNet.Components.Services
{
    public class SessionService
    {
        private readonly ProtectedSessionStorage _sessionStorage;

        public SessionService(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public async Task GuardarUsuario(Usuario usuario)
        {
            await _sessionStorage.SetAsync("usuario", usuario);
        }

        public async Task<Usuario?> GetUsuario()
        {
            var result = await _sessionStorage.GetAsync<Usuario>("usuario");
            return result.Success ? result.Value : null;
        }

        public async Task<bool> EstaLogueado()
        {
            var usuario = await GetUsuario();
            return usuario is not null;
        }

        public async Task CerrarSesion()
        {
            await _sessionStorage.DeleteAsync("usuario");
        }
    }
}
