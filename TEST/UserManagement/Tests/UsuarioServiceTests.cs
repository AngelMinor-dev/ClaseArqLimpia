using Xunit;
using UserManagement.Models;
using UserManagement.Services;
using NuGet.Frameworks;

namespace UserManagement.Tests
{
    public class UsuarioServiceTests
    {
        public void InsertUserTest()
        { 
            //Arranque
            var servicio = new UsuarioService();
            var usuario = new Usuario(1,"angel","minor.dev@outlook.com");

            //Accion
            servicio.CrearUsuario(usuario);
            var result = servicio.ObtenerUsuarioPorId(usuario.Id);

            //Aserción
            Assert.NotNull(result);
            Assert.Equal(usuario.Nombre, result.Nombre);
            Assert.Equal(usuario.Email, result.Email);
        }


    }
}