using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIClientes.Context;
using APIClientes.Models;
using APIClientes.Interfaces;

namespace APIClientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesContext _context;
        private readonly IClienteService _clienteService;

        public ClientesController(ClientesContext context, IClienteService clienteService)
        {
            _context = context;
            _clienteService = clienteService;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = _clienteService.GetAllClientes();

            if (clientes == null)
            {
                return NotFound("No hay clientes asociados.");
            }
            return clientes;
        }

        // GET: api/Clientes/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetClienteByID(int id)
        {
            var cliente = _clienteService.GetClienteById(id);

            if (cliente == null)
            {
                return NotFound("No existe un cliente con ese ID.");
            }            

            return cliente;
        }

       // GET: api/Clientes/nombre
       [HttpGet("{nombre}")]
        public async Task<ActionResult<Cliente>> SearchByName(string nombre)
        {
            var cliente = _clienteService.GetClienteByName(nombre);

            if (cliente == null)
            {
                return NotFound("No existe un cliente con ese nombre.");
            }          

            return cliente;
        }

        //    POST: api/Clientes
        //   [HttpPost]
        //    public async Task<ActionResult<Cliente>> InsertCliente(Cliente cliente)
        //    {
        //        if (_context.Clientes == null)
        //        {
        //            return Problem("Entity set 'ClientesContext.Clientes'  is null.");
        //        }
        //        _context.Clientes.Add(cliente);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction("GetCliente", new { id = cliente.IdCliente }, cliente);
        //    }


        //    PUT: api/Clientes/5
        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> UpdateCliente(int id, Cliente cliente)
        //    {
        //        if (id != cliente.IdCliente)
        //        {
        //            return BadRequest();
        //        }

        //        _context.Entry(cliente).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ClienteExists(id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return NoContent();
        //    }



        //    // DELETE: api/Clientes/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteCliente(int id)
        //    {
        //        if (_context.Clientes == null)
        //        {
        //            return NotFound();
        //        }
        //        var cliente = await _context.Clientes.FindAsync(id);
        //        if (cliente == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Clientes.Remove(cliente);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool ClienteExists(int id)
        //    {
        //        return (_context.Clientes?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        //    }
    }
}
