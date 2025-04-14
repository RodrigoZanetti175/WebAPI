using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IUsuarioInterface
    {
        Task<ServiceResponse<UsuarioModel>> Login(string email, string password);
        Task<ServiceResponse<List<UsuarioModel>>> Cadastro(UsuarioModel novoUsuario);

        Task<ServiceResponse<List<UsuarioModel>>> Deletar(int id);

        Task<ServiceResponse<List<UsuarioModel>>> Editar(UsuarioModel editadoUsuario);

    }
}
