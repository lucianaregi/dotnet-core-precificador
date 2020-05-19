using APIPrecificador.Context;
using APIPrecificador.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPrecificador.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MarkupsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public MarkupsController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Markup>> Get()
        {
            return _context.Markups.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterMarkup")]
        public ActionResult<Markup> Get(int id)
        {
            var markup = _context.Markups.AsNoTracking()
                .FirstOrDefault(p => p.MarkupId == id);

            if (markup == null)
            {
                return NotFound();
            }
            return markup;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Markup markup)
        {
            
            _context.Markups.Add(markup);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterMarkup",
                new { id = markup.MarkupId }, markup);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Markup markup)
        {
            
            if (id != markup.MarkupId)
            {
                return BadRequest();
            }

            _context.Entry(markup).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Markup> Delete(int id)
        {
            var markup = _context.Markups.FirstOrDefault(p => p.MarkupId == id);
           
            if (markup == null)
            {
                return NotFound();
            }
            _context.Markups.Remove(markup);
            _context.SaveChanges();
            return markup;
        }
    }
}
