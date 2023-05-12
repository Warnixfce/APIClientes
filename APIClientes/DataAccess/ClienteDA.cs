using APIClientes.Context;
using APIClientes.Models;

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
            List<Cliente> clientes = new (_context.Clientes.ToList());           
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

        public bool InsertCliente(Cliente cliente)
        {
            Cliente clienteMatch = _context.Clientes.FirstOrDefault(m => m.Cuit == cliente.Cuit); //validar que ya exista
            if (clienteMatch != null )
            {
                return false;
            }
            else
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return true;
            }
        }

    }
}
