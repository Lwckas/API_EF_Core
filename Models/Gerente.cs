using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Xunit;

namespace API_1.Models
{
    public class Gerente
    {

        [Required]
        [Key]
        public int Id { get; internal set; }
        public string Nome { get; set; }
       
        [JsonIgnore]
        public virtual List<Cinema> Cinemas { get; set; }



    }
}
