using ApiBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repository.Repository
{
    public interface IMantenimientoRepository
    {
        Task<Mantenimiento> Add(Mantenimiento mantenimiento);
        Task<IEnumerable<Mantenimiento>> GetByLibro(int libroId);
        Task<IEnumerable<Mantenimiento>> GetByTecnico(int tecnicoId);
    }
}