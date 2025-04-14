using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime creationDate { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime alterationDate { get; set; } = DateTime.Now.ToLocalTime();


    }
}
