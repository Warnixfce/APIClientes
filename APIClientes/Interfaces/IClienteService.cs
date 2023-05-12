using APIClientes.Models;

namespace APIClientes.Interfaces
{
    public interface IClienteService
    {
        public List<Cliente> GetAllClientes();

        public Cliente GetClienteById(int id);

        public Cliente GetClienteByName(string name);

    }
}
