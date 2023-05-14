namespace APIClientes.Interfaces
{
    public interface IValidationsService
    {
        public bool FechaNacimientoValidation(string fechaNac, ref string message);

        public bool CuitValidation(ref string cuit, ref string message);

        public bool EmailValidation(string email, ref string message);

    }
}
