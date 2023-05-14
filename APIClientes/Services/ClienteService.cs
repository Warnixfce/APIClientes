using APIClientes.Context;
using APIClientes.DataAccess;
using APIClientes.Interfaces;
using APIClientes.Models;
using Microsoft.EntityFrameworkCore;

namespace APIClientes.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteDA _clienteDA;

        public ClienteService(ClienteDA clienteDA)
        {
            _clienteDA = clienteDA;
        }

        public List<Cliente> GetAllClientes()
        {
            List<Cliente> clientes = _clienteDA.GetAllClientes();
            return clientes;
        }

        public Cliente GetClienteById(int id)
        {
            Cliente clienteMatch = _clienteDA.GetClienteById(id);
            return clienteMatch;
        }

        public Cliente GetClienteByName(string name)
        {
            Cliente clienteMatch = _clienteDA.GetClienteByName(name);
            return clienteMatch;
        }

        public bool InsertCliente(Cliente cliente, ref string message)
        {
            bool result = _clienteDA.InsertCliente(cliente, ref message);
            return result;
        }

        public bool UpdateCliente(string cuit, Cliente cliente, ref string message)
        {
            bool result = _clienteDA.UpdateCliente(cuit, cliente, ref message);
            return result;
        }
    }
}
