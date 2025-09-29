using Dapper.Contrib.Extensions;
using System;

namespace ApiBiblioteca.Models
{
    [Table("dbo.Libro")]
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string Editorial { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int NumeroPaginas { get; set; }
        public bool Activo { get; set; }


    }
}
