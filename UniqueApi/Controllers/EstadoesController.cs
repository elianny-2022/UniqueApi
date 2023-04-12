﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqueApi.DAL;
using UniqueApi.Models;

namespace UniqueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoesController : ControllerBase
    {
        private readonly Contexto _context;

        public EstadoesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Estadoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
          if (_context.Estados == null)
          {
              return NotFound();
          }
            return await _context.Estados.ToListAsync();
        }

        // GET: api/Estadoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
          if (_context.Estados == null)
          {
              return NotFound();
          }
            var estado = await _context.Estados.FindAsync(id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/Estadoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, Estado estado)
        {
            if (id != estado.EstadoId)
            {
                return BadRequest();
            }

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Estadoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(Estado estado)
        {
          if (_context.Estados == null)
          {
              return Problem("Entity set 'Contexto.Estados'  is null.");
          }
            _context.Estados.Add(estado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstado", new { id = estado.EstadoId }, estado);
        }

        // DELETE: api/Estadoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            if (_context.Estados == null)
            {
                return NotFound();
            }
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoExists(int id)
        {
            return (_context.Estados?.Any(e => e.EstadoId == id)).GetValueOrDefault();
        }
    }
}
