using System;
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
    public class ClientesController : ControllerBase
    {
        private readonly Contexto _context;

        public ClientesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
          if (_context.Clientes == null)
          {
              return NotFound();
          }
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;

        }
        // GET: api/Clientes/nombre,clave
        [HttpGet("{email},{clave}")]
        public async Task<ActionResult<Cliente>> GetCliente(string email, string clave)
        {
            string decryptedClave = "";
            string decryptedEmail = "";

            foreach (var letra in clave)
                decryptedClave += CharacterDecrypter(letra);

            foreach (var letra in email)
                decryptedEmail += CharacterDecrypter(letra);

            var clientes = await _context.Clientes.FirstOrDefaultAsync(c => c.Email.Equals(email) && c.Clave.Equals(clave));

            if (clientes == null)
            {
                return NotFound();
            }

            return clientes;
        }


        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
          if (_context.Clientes == null)
          {
              return Problem("Entity set 'Contexto.Clientes'  is null.");
          }
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (_context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.ClienteId == id)).GetValueOrDefault();
        }
        private char CharacterDecrypter(char character)
        {
            char result = ' ';
            switch (character)
            {
                case 'e':
                    {
                        result = 'A';
                        break;
                    }
                case 't':
                    {
                        result = 'a';
                        break;
                    }
                case 'q':
                    {
                        result = 'B';
                        break;
                    }
                case 'k':
                    {
                        result = 'b';
                        break;
                    }
                case 'r':
                    {
                        result = 'C';
                        break;
                    }
                case 'M':
                    {
                        result = 'c';
                        break;
                    }
                case 's':
                    {
                        result = 'D';
                        break;
                    }
                case 'j':
                    {
                        result = 'd';
                        break;
                    }
                case 'f':
                    {
                        result = 'E';
                        break;
                    }
                case 'n':
                    {
                        result = 'e';
                        break;
                    }
                case 'g':
                    {
                        result = 'F';
                        break;
                    }
                case 'D':
                    {
                        result = 'f';
                        break;
                    }
                case 'p':
                    {
                        result = 'G';
                        break;
                    }
                case 'S':
                    {
                        result = 'g';
                        break;
                    }
                case 'G':
                    {
                        result = 'H';
                        break;
                    }
                case 'l':
                    {
                        result = 'h';
                        break;
                    }
                case 'F':
                    {
                        result = 'I';
                        break;
                    }
                case 'Q':
                    {
                        result = 'i';
                        break;
                    }
                case 'm':
                    {
                        result = 'J';
                        break;
                    }
                case 'B':
                    {
                        result = 'j';
                        break;
                    }
                case 'V':
                    {
                        result = 'K';
                        break;
                    }
                case 'h':
                    {
                        result = 'k';
                        break;
                    }
                case 'P':
                    {
                        result = 'L';
                        break;
                    }
                case 'A':
                    {
                        result = 'l';
                        break;
                    }
                case 'H':
                    {
                        result = 'M';
                        break;
                    }
                case 'Z':
                    {
                        result = 'm';
                        break;
                    }
                case 'o':
                    {
                        result = 'N';
                        break;
                    }
                case 'v':
                    {
                        result = 'n';
                        break;
                    }
                case 'K':
                    {
                        result = 'O';
                        break;
                    }
                case 'J':
                    {
                        result = 'o';
                        break;
                    }
                case 'b':
                    {
                        result = 'P';
                        break;
                    }
                case 'W':
                    {
                        result = 'p';
                        break;
                    }
                case 'd':
                    {
                        result = 'Q';
                        break;
                    }
                case 'E':
                    {
                        result = 'q';
                        break;
                    }
                case 'a':
                    {
                        result = 'R';
                        break;
                    }
                case 'i':
                    {
                        result = 'r';
                        break;
                    }
                case 'x':
                    {
                        result = 'S';
                        break;
                    }
                case 'O':
                    {
                        result = 's';
                        break;
                    }
                case 'L':
                    {
                        result = 'T';
                        break;
                    }
                case 'w':
                    {
                        result = 't';
                        break;
                    }
                case 'R':
                    {
                        result = 'U';
                        break;
                    }
                case 'T':
                    {
                        result = 'u';
                        break;
                    }
                case 'y':
                    {
                        result = 'V';
                        break;
                    }
                case 'X':
                    {
                        result = 'v';
                        break;
                    }
                case 'N':
                    {
                        result = 'W';
                        break;
                    }
                case 'U':
                    {
                        result = 'w';
                        break;
                    }
                case 'c':
                    {
                        result = 'X';
                        break;
                    }
                case 'I':
                    {
                        result = 'x';
                        break;
                    }
                case 'z':
                    {
                        result = 'Y';
                        break;
                    }
                case 'C':
                    {
                        result = 'y';
                        break;
                    }
                case 'Y':
                    {
                        result = 'Z';
                        break;
                    }
                case 'u':
                    {
                        result = 'z';
                        break;
                    }


                default:
                    {
                        result = character;
                        break;
                    }
            }
            return result;
        }
    }
}
