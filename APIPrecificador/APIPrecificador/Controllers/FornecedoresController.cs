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
    public class FornecedoresController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FornecedoresController(AppDbContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> Get()
        {
            return _context.Fornecedores.AsNoTracking().ToList();
        }

        [HttpGet("{id}", Name = "ObterFornecedor")]
        public ActionResult<Fornecedor> Get(int id)
        {
            var fornecedor = _context.Fornecedores.AsNoTracking()
                .FirstOrDefault(p => p.FornecedorId == id);

            if (fornecedor == null)
            {
                return NotFound();
            }
            return fornecedor;
        }

        [HttpPost]
        public ActionResult Post([FromBody]Fornecedor fornecedor)
        {


            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterFornecedor",
                new { id = fornecedor.FornecedorId }, fornecedor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Fornecedor fornecedor)
        {

            if (id != fornecedor.FornecedorId)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Fornecedor> Delete(int id)
        {
            var fornecedor = _context.Fornecedores.FirstOrDefault(p => p.FornecedorId == id);


            if (fornecedor == null)
            {
                return NotFound();
            }
            _context.Fornecedores.Remove(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }
    }
}
