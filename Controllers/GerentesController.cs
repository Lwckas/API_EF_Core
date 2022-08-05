using API_1.Data;
using API_1.Models;
using Microsoft.AspNetCore.Mvc;


namespace API_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerentesController : ControllerBase
    {
        public AppDbContext _conn { get; set; }

        public GerentesController(AppDbContext conn)
        {
            _conn = conn;
        }   

        [HttpPost]
        public void PostGerentes([FromBody] Gerente g)
        {
            _conn.Gerentes.Add(g);
            _conn.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Gerente> GetGerentes()
        {
            return _conn.Gerentes;
        }

        
        [HttpGet("{id}")]
        public Gerente GetGerente(int id)
        {
            return _conn.Gerentes.FirstOrDefault(g => g.Id == id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGerente(int id, [FromBody] Gerente gNovo)
        {
            Gerente g = GetGerente(id);
            if (g == null)
                return NotFound();
            
            g.Nome = gNovo.Nome;
            _conn.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGerente (int id)
        {
            Gerente g = GetGerente(id);
            if (g == null)
                return NotFound();

            _conn.Remove(g);
            _conn.SaveChanges();
            return NoContent();

        }

    }
}
