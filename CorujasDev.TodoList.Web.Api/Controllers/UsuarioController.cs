using CorujasDev.TodoList.Service.Interfaces;
using CorujasDev.TodoList.Service.ViewModels.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace CorujasDev.TodoList.Web.Api.Controllers
{
    [Produces("application/json")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            usuarioService = _usuarioService;
        }

        [HttpGet]
        [Route("api/v1/usuario/login")]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                UsuarioViewModel usuario = _usuarioService.Login(login.Email, Util.Criptografia.Senha.Criptografa(login.Senha));

                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        
    }
}