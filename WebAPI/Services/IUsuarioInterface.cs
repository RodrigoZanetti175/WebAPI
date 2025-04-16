using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUsuarioInterface
    {
        Task<ServiceResponse<List<UsuarioModel>>> Login();
        Task<ServiceResponse<List<UsuarioModel>>> Cadastro(UsuarioModel novoUsuario);

        Task<ServiceResponse<List<UsuarioModel>>> Deletar(int id);

        Task<ServiceResponse<List<UsuarioModel>>> Editar(UsuarioModel editadoUsuario);

    }
}
