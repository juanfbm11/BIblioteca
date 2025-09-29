using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBiblioteca.Models
{
    [Table("dbo.Tecnico")]
    public class Tecnico
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Especialidad { get; set; } = string.Empty;
        public string Contacto { get; set; } = string.Empty;

        // Relaciones
        public List<Mantenimiento> Mantenimientos { get; set; } = new List<Mantenimiento>();


    }
}
