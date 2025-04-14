using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<UsuarioModel>>> Login(string email, string password) 
        {
            return Ok(await _usuarioInterface.Login(email, password));
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> Cadastro(UsuarioModel usuario)
        {
            return Ok(await _usuarioInterface.Cadastro(usuario));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<UsuarioModel>>>> Editar(UsuarioModel usuarioModel)
        {
            return Ok(await _usuarioInterface.Editar(usuarioModel));
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<UsuarioModel>>> Deletar(int id)
        {
            return Ok(await _usuarioInterface.Deletar(id));
        }
    }
}
