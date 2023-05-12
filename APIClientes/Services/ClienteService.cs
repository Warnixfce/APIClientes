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

        public void InsertCliente(Cliente cliente)
        {
            bool result = _clienteDA.InsertCliente(cliente);

            if (result == false)
            {
                
            }
            else
            {
               
            }
        }
    }
}
