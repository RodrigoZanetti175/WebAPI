using Microsoft.EntityFrameworkCore;
using WebAPI.DataContext;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private ApplicationDbContext _context;
        public UsuarioService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<UsuarioModel>>> Cadastro(UsuarioModel novoUsuario)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = new ServiceResponse<List<UsuarioModel>>();
            try
            {
                if (novoUsuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Informe os dados do usuário";
                    return serviceResponse;
                }
                if (!novoUsuario.Email.Contains("@"))
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Informe um email válido";
                    return serviceResponse;
                }
                _context.Add(novoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Usuarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse; 
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> Deletar(int id)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = new ServiceResponse<List<UsuarioModel>>();

            try
            {
                UsuarioModel usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);
                if(usuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Não foi possível encontrar este usuário";
                    return serviceResponse;
                }
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Usuarios.ToList();

            }
            catch(Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<UsuarioModel>>> Editar(UsuarioModel editadoUsuario)
        {
            ServiceResponse<List<UsuarioModel>> serviceResponse = new ServiceResponse<List<UsuarioModel>>();

            try
            {
                UsuarioModel usuario = _context.Usuarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoUsuario.Id);
                if (usuario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Insira os dados a serem editados";
                    return serviceResponse;
                }

                usuario.alterationDate = DateTime.Now.ToLocalTime();

                _context.Usuarios.Update(editadoUsuario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Usuarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UsuarioModel>> Login(string email, string password)
        {
            ServiceResponse<UsuarioModel> serviceResponse = new ServiceResponse<UsuarioModel>();

            try
            {
                if (email == null || password == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Sucesso = false;
                    serviceResponse.Mensagem = "Informe dados válidos";
                    return serviceResponse;
                }
                serviceResponse.Dados = _context.Usuarios.FirstOrDefault(x=>x.Email == email && x.Password == password);
            }
            catch (Exception ex)
            {
                serviceResponse.Sucesso=false;
                serviceResponse.Mensagem=ex.Message;
            }
            return serviceResponse;
        }

    }
}
