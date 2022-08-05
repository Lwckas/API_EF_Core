using System.ComponentModel.DataAnnotations;

namespace API_1.Models
{
    public class Sessao
    {
        [Required]
        [Key]
        public int Id { get; internal set; }
        public virtual Cinema cinema { get; set; }
        public virtual Filme filme { get; set; }
        public int cinemaId { get; set; }
        public int filmeId { get; set; }
        public DateTime HoraInicio { get; set; }

    }
}
