using System.ComponentModel.DataAnnotations;

namespace API_1.Data.DTOs
{
    public class CreateFilmeDTO
    {
        [Required(ErrorMessage = "O campo Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatório")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo Duração é obrigatório")]
        [Range(1, 300, ErrorMessage = "A duração deve ser entre 1 e 300 minutos")]
        public int Duracao { get; set; }
    }
}
