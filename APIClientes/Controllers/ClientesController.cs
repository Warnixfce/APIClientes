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
        private readonly IClienteService _clienteService;
        private readonly IValidationsService _validationsService;

        public ClientesController(IClienteService clienteService, IValidationsService validationsService)
        {
            _clienteService = clienteService;
            _validationsService = validationsService;
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

        // POST: api/Clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> InsertCliente(Cliente cliente)
        {
            #region DataValidations
            string message = "";
            // -Fecha de nacimiento      
            var resultFechaNac = _validationsService.FechaNacimientoValidation(cliente.FechaNacimiento.ToString(), ref message);
            if (resultFechaNac == false) { return BadRequest(message); }
            // -CUIT
            string cuit = cliente.Cuit;
            var resultCuit = _validationsService.CuitValidation(ref cuit, ref message);
            if (resultCuit == false) { return BadRequest(message); }
            cliente.Cuit = cuit;
            // -Email
            var resultEmail = _validationsService.EmailValidation(cliente.Email, ref message);
            if (resultEmail == false) { return BadRequest(message); }
            #endregion

            var result = _clienteService.InsertCliente(cliente, ref message);
            if (result == false) { return BadRequest(message); }

            return Ok($"Cliente ingresado con éxito!\n\n{cliente}");
        }


        // PUT: api/Clientes/cuit
        [HttpPut("{cuit}")]
        public async Task<IActionResult> UpdateCliente(string cuit, Cliente cliente)
        {
            string message = "";
            var resultCuit = _validationsService.CuitValidation(ref cuit, ref message);
            if (resultCuit == false) { return BadRequest(message); }
            cliente.Cuit = cuit;

            var result = _clienteService.UpdateCliente(cuit, cliente, ref message);
            if (result == false) { return BadRequest(message); }

            return Ok($"Cliente actualizado con éxito!\n\n{cliente}");
        }

        // DELETE: api/Clientes/cuit
        [HttpDelete("{cuit}")]
        public async Task<IActionResult> DeleteCliente(string cuit)
        {
            string message = "";
            var resultCuit = _validationsService.CuitValidation(ref cuit, ref message);
            if (resultCuit == false) { return BadRequest(message); }

            Cliente cliente = _clienteService.GetClienteByCuit(cuit, ref message);
            if (cliente == null) { return BadRequest(message); }

            _clienteService.DeleteCliente(cliente);

            return Ok($"Cliente eliminado con éxito! \n\nDatos del cliente:\n{cliente}");
        }
    }
}
