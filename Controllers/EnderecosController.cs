using API_1.Data;
using API_1.Models;
using Microsoft.AspNetCore.Mvc;


namespace API_1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecosController : ControllerBase
    {
        public AppDbContext _conn { get; set; }

        public EnderecosController(AppDbContext conn)
        {
            _conn = conn;
        }   

        [HttpPost]
        public void PostEndereco([FromBody] Endereco endereco)
        {
            //Console.WriteLine($"Entrei aqui {endereco}");
            _conn.Enderecos.Add(endereco);
            _conn.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Endereco> GetEndereco()
        {
            return _conn.Enderecos;
        }

        
        [HttpGet("{id}")]
        public Endereco GetEndereco(int id)
        {
            return _conn.Enderecos.FirstOrDefault(E => E.Id == id);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEndereco(int id, [FromBody] Endereco eNovo)
        {
            Endereco e = GetEndereco(id);
            if (e == null)
                return NotFound();
            
            e.Logradouro = eNovo.Logradouro;
            e.Numero = eNovo.Numero;
            e.Bairro = eNovo.Bairro;
            _conn.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEndereco (int id)
        {
            Endereco e = GetEndereco(id);
            if (e == null)
                return NotFound();

            _conn.Remove(e);
            _conn.SaveChanges();
            return NoContent();

        }

    }
}
