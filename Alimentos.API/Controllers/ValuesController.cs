using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alimentos.API.Data;
using Alimentos.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alimentos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly DataContext _contexto;
        public ValuesController(DataContext contexto)
        {
            _contexto = contexto;

        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           try
           {
               var results = _contexto.Ingredientes.ToListAsync();
               return Ok(results);
           }
           catch (System.Exception)
           {
               return  this.StatusCode(StatusCodes.Status500InternalServerError, "Consulta não está funcionando.");
           }     
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
           try
           {
               var results = _contexto.Ingredientes.FirstOrDefaultAsync(x => x.IngredienteId == id);
               return Ok(results);
           }
           catch (System.Exception)
           {
               return  this.StatusCode(StatusCodes.Status500InternalServerError, "Consulta não está funcionando.");
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
