using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API_1.Models
{
    public class Cinema
    {
        [Required]
        [Key]
        public int Id { get; internal set; }
        
        public string Nome { get; set; }
        
        public virtual Endereco Endereco { get; set; }
        
        public virtual Gerente Gerente { get; set; }
        
        [JsonIgnore]
        public virtual List<Sessao> sessoes { get; set; }
        
        public int enderecoId { get; set; }
        
        public int gerenteId { get; set; }

    }
}
