using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proagil.Repository;

namespace Proagil.WEBAPI.Controllers
{
    [Route("prodest/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly ProagilContext _context;

        public ValuesController(ProagilContext context)
        {
            _context = context;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {   
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falhou meu chapa, bd n encontrado!");
                throw;
            }
            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {   
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
                return Ok(results);
                
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falhou meu chapa, bd n encontrado!");
                throw;
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
