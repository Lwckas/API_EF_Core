using API_1.Data;
using API_1.Models;
using Microsoft.AspNetCore.Mvc;


namespace API_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemasController : ControllerBase
    {
        public AppDbContext _conn { get; set; }

        public CinemasController(AppDbContext conn)
        {
            _conn = conn;
        }   

        [HttpPost]
        public void PostCinema([FromBody] Cinema cinema)
        {
            _conn.Cinemas.Add(cinema);
            _conn.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Cinema> GetCinema()
        {
            return _conn.Cinemas;
        }

        
        [HttpGet("{id}")]
        public Cinema GetCinema(int id)
        {
            return _conn.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, [FromBody] Cinema cNovo)
        {
            Cinema cinema = GetCinema(id);
            if (cinema == null)
                return NotFound();
            
            cinema.Nome = cNovo.Nome;
            cinema.enderecoId = cNovo.enderecoId;
            cinema.gerenteId = cNovo.gerenteId;
            _conn.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCinema (int id)
        {
            Cinema cinema = GetCinema(id);
            if (cinema == null)
                return NotFound();

            _conn.Remove(cinema);
            _conn.SaveChanges();
            return NoContent();

        }

    }
}
