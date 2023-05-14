using APIClientes.Context;
using APIClientes.Interfaces;
using APIClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.DataAccess
{
    public class ClienteDA
    {
        private readonly ClientesContext _context;

        public ClienteDA(ClientesContext context)
        {
            _context = context;
        }

        public List<Cliente> GetAllClientes()
        {
            List<Cliente> clientes = new(_context.Clientes.ToList());
            return clientes;
        }

        public Cliente GetClienteById(int id)
        {
            Cliente clienteMatch = _context.Clientes.FirstOrDefault(m => m.IdCliente == id);
            return clienteMatch;
        }

        public Cliente GetClienteByName(string name)
        {
            Cliente clienteMatch = _context.Clientes.FirstOrDefault(m => m.Nombres.Contains(name));
            return clienteMatch;
        }

        public bool InsertCliente(Cliente cliente, ref string message)
        {
            
            Cliente clienteMatch = _context.Clientes.FirstOrDefault(m => m.Cuit == cliente.Cuit); //validar que ya exista
            if (clienteMatch != null)
            {
                message = $"Ingreso inválido. El cliente ya se encuentra ingresado. Datos ingresados:\n\n{cliente}";
                return false;
            }
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCliente(string cuit, Cliente cliente, ref string message)
        {
            Cliente clienteMatch = _context.Clientes.FirstOrDefault(m => m.Cuit == cliente.Cuit);
            if (clienteMatch == null)
            {
                message = $"Actualización incompleta. El cliente a actualizar no se encuentra ingresado previamente. Datos ingresados:\n\n{cliente}";
                return false;
            }            
            clienteMatch.Nombres = cliente.Nombres;
            clienteMatch.Apellidos = cliente.Apellidos;
            clienteMatch.FechaNacimiento = cliente.FechaNacimiento;
            clienteMatch.Domicilio = cliente.Domicilio;
            clienteMatch.TelCelular = cliente.TelCelular;
            clienteMatch.Email = cliente.Email;
            _context.SaveChanges();
            return true;

           
            
        }

    }
}
