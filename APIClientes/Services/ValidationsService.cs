using APIClientes.Interfaces;

namespace APIClientes.Services
{
    public class ValidationsService : IValidationsService
    {
        public bool FechaNacimientoValidation(string fechaNac)
        {
            DateTime fechaNacOk;

            if (!DateTime.TryParse(fechaNac, out fechaNacOk)) //validar que sea una fecha
            {
                return false;
            }            
            if (fechaNacOk.Date >= DateTime.Now.Date) //validar que no sea mayor a hoy
            {
                return false;
            }
            int years = DateTime.Now.Year - fechaNacOk.Year; //validar que no tenga mas de 120 años
            if (years >= 120)
            {
                return false;
            }
            return true;
        }

        public bool CuitValidation(string cuit)
        {
            if (cuit.Contains("-")) { cuit.Replace("-", ""); }  //sacar el guión
            if (cuit.Contains(" ")) { cuit.Replace(" ", ""); } //sacar espacios (donde sea)
            if (!int.TryParse(cuit, out int cuitOk)) //validar que no hayan letras
            {
                return false;
            }
            if (cuit.Length != 11) //validar que tenga 11 caracteres
            {
                return false;
            }

            cuit.ToArray();
            string cuitWithSlash = "";
            for (int i = 0; i < cuit.Length; i++)
            {
                if ((i == 2) || (i == cuit.Length))
                {
                    cuitWithSlash += "-";
                }
                cuitWithSlash += cuit[i];
            }
            return true;
        }

        public bool EmailValidation(string email)
        {
            return true;
        }
    }
}
