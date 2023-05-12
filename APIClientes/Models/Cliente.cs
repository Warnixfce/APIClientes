using System;
using System.Collections.Generic;

namespace APIClientes.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Cuit { get; set; } = null!;
        public string Domicilio { get; set; } = null!;
        public string? TelCelular { get; set; }
        public string? Email { get; set; }
    }
}
