using ApiBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repository.Repository
{
    public interface IMantenimientoRepository
    {
        Task<IEnumerable<Mantenimiento>> GetAll();
        Task<Mantenimiento?> GetById(int id);
        Task<Mantenimiento> Add(Mantenimiento mantenimiento);
        Task<bool> Update(Mantenimiento mantiento);
        Task<bool> Delete(int Id);        
        Task<IEnumerable<Mantenimiento>> GetByLibro(int libroId);
        Task<IEnumerable<Mantenimiento>> GetByTecnico(int tecnicoId);
        
    }
}

