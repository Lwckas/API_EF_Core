using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_1.Models
{
    public class Endereco
    {
        [Required]
        [Key]
        public int Id { get; internal set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public virtual Cinema Cinema { get; set; }

    }
}
