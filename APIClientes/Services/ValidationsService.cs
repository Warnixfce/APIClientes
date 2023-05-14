using APIClientes.Interfaces;
using System.Linq;

namespace APIClientes.Services
{
    public class ValidationsService : IValidationsService
    {
        public bool FechaNacimientoValidation(string fechaNac, ref string message)
        {
            DateTime fechaNacOk;

            if (!DateTime.TryParse(fechaNac, out fechaNacOk)) //validar que sea una fecha. Esto ya lo hace Postman por default pero porlas lo agrego
            {
                message = "Fecha incorrecta. La fecha ingresada no corresponde a una fecha válida.";
                return false;
            }            
            if (fechaNacOk.Date >= DateTime.Now.Date) //validar que no sea mayor a hoy
            {
                message = "Fecha incorrecta. El cliente no puede tener una fecha de nacimiento futura.";
                return false;
            }
            int years = DateTime.Now.Year - fechaNacOk.Year; //validar que no tenga mas de 120 años
            if (years >= 120)
            {
                message = "Fecha incorrecta. El cliente no puede tener más de 120 años.";
                return false;
            }
            return true;
        }

        public bool CuitValidation(ref string cuit, ref string message)
        {
            int maxValue = 11;
            if (cuit.Contains("-")) { cuit = cuit.Replace("-", ""); }  //sacar el guión
            if (cuit.Contains(" ")) { cuit = cuit.Replace(" ", ""); } //sacar espacios (donde sea)
            if (!long.TryParse(cuit, out long cuitOk)) //validar que no hayan letras
            {
                message = "CUIT incorrecto. No debe tener letras, sólo debe tener números.";
                return false;
            }
            if (cuit.Length != maxValue) //validar que tenga 11 caracteres
            {
                message = $"CUIT incorrecto. No debe tener más de {maxValue} caracteres.";
                return false;
            }
                        
            string cuitWithSlash = ""; //agregarle el guión en los lugares correspondientes así se guarda con un guión en la DB
            for (int i = 0; i < cuit.Length; i++)
            {
                if ((i == 2) || (i == cuit.Length - 1))
                {
                    cuitWithSlash += "-";
                }
                if (i == 0)
                {
                    cuitWithSlash += cuit.Substring(i, i+1);
                }
                else
                {
                    cuitWithSlash += cuit.Substring(i, 1);
                }
                
            }

            cuit = cuitWithSlash;
            return true;
        }

        public bool EmailValidation(string email, ref string message)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                message = "Email incorrecto. No puede finalizar con un punto.";
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);                
                return addr.Address == trimmedEmail;
            }
            catch
            {
                message = "Email incorrecto. No es un mail válido.";
                return false;
            }


            //if (!email.Contains("@"))
            //{
            //    message = "Email incorrecto. Debe tener una dirección válida";
            //    return false;
            //}
            //int count = email.Count(f => f == '@');
            //if (count != 1)
            //{
            //    message = "Email incorrecto. La dirección de email debe contenter 1 solo '@'.";
            //    return false;
            //}
            //int index = email.IndexOf("@");
            //string endOfEmail = email.Substring(index);
        }
    }
}
