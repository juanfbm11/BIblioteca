using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiBiblioteca.Models
{
    [Table("dbo.Mantenimiento")]
    public class Mantenimiento
    {
        [Key]
        public int Id { get; set; } 

        public int LibroId { get; set; }
        public int TecnicoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
    
     // Relaciones de navegación
    public Libro Libro { get; set; } = null!;
        public Tecnico Tecnico { get; set; } = null!;

    }
}