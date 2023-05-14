using APIClientes.Models;

namespace APIClientes.Interfaces
{
    public interface IClienteService
    {
        public List<Cliente> GetAllClientes();

        public Cliente GetClienteById(int id);

        public Cliente GetClienteByName(string name);

        public bool InsertCliente(Cliente cliente, ref string message);

        public bool UpdateCliente(string cuit, Cliente cliente, ref string message);

    }
}
