using API_1.Data;
using API_1.Models;
using Microsoft.AspNetCore.Mvc;


namespace API_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessoesController : ControllerBase
    {
        public AppDbContext _conn { get; set; }

        public SessoesController(AppDbContext conn)
        {
            _conn = conn;
        }   

        [HttpPost]
        public void PostSessao([FromBody] Sessao s)
        {
            _conn.Sessoes.Add(s);
            _conn.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Sessao> GetSessoes()
        {
            return _conn.Sessoes;
        }

        
        [HttpGet("{id}")]
        public Sessao GetSessao(int id)
        {
            return _conn.Sessoes.FirstOrDefault(s => s.Id == id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSessao(int id, [FromBody] Sessao sNovo)
        {
            Sessao s = GetSessao(id);
            if (s == null)
                return NotFound();
            
            s.cinemaId = sNovo.cinemaId;
            s.filmeId = sNovo.filmeId;
            _conn.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSessao (int id)
        {
            Sessao s = GetSessao(id);
            if (s == null)
                return NotFound();

            _conn.Remove(s);
            _conn.SaveChanges();
            return NoContent();

        }

    }
}
