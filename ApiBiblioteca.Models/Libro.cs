using Dapper.Contrib.Extensions;
using System;

namespace ApiBiblioteca.Models
{
    [Table("dbo.Libro")]
    public class Libro
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor {  get; set; }
        public string Editorial { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int NumeroPaginas { get; set; }
        public bool Activo { get; set; }


    }
}
