using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIClientes.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }

        [Required]
        public string Nombres { get; set; } = null!;

        [Required]
        public string Apellidos { get; set; } = null!;

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public string Cuit { get; set; } = null!;

        [Required]
        public string Domicilio { get; set; } = null!;

        [Required]
        public string TelCelular { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        public override string ToString()
        {
            return string.Concat($"Nombres: {Nombres} \nApellidos: {Apellidos} \nFecha de Nacimiento: {FechaNacimiento.ToString("yyy/MM/dd")}" +
                $"\nCUIT: {Cuit} \nDomicilio: {Domicilio} \nTeléfono celular: {TelCelular} \nEmail: {Email}");
        }
    }
}
