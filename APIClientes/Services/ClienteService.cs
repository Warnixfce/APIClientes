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
            Cliente cliente = _clienteDA.GetClienteById(id);
            return cliente;
        }

        public Cliente GetClienteByName(string name)
        {
            Cliente clienteMatch = _clienteDA.GetClienteByName(name);
            return clienteMatch;
        }
    }
}
