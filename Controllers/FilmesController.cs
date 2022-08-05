using API_1.Data;
using API_1.Models;
using Microsoft.AspNetCore.Mvc;


namespace API_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        public AppDbContext _conn { get; set; }

        public FilmesController(AppDbContext conn)
        {
            _conn = conn;
        }   

        [HttpPost]
        public void PostFilme([FromBody] Filme filme)
        {
            _conn.Filmes.Add(filme);
            _conn.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Filme> GetFilmes()
        {
            return _conn.Filmes;
        }

        
        [HttpGet("{id}")]
        public Filme GetFilme(int id)
        {
            return _conn.Filmes.FirstOrDefault(filme => filme.Id == id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFilme(int id, [FromBody] Filme fNovo)
        {
            Filme filme = GetFilme(id);
            if (filme == null)
                return NotFound();
            
            filme.Titulo = fNovo.Titulo;
            filme.Genero = fNovo.Genero;
            filme.Duracao = fNovo.Duracao;
            filme.Diretor = fNovo.Diretor;
            _conn.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFilme (int id)
        {
            Filme filme = GetFilme(id);
            if (filme == null)
                return NotFound();

            _conn.Remove(filme);
            _conn.SaveChanges();
            return NoContent();

        }

    }
}
