using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.Repository.Data;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {

        public DataContext _context { get; }

        public ValuesController(DataContext context)
        {
            this._context = context;

        }


        [HttpGet]
         public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();
                 return Ok(results) ;
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou");
            }
           
        }
       // public ActionResult<IEnumerable<Evento>> Get()
        //{
          //  return _context.Eventos.ToList();
        //}

        






        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.Id == id);
                 return Ok(results) ;
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Banco de Dados Falhou");
            }
            
        }
    }

}
