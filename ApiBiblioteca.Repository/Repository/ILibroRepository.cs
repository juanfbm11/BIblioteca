using ApiBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repository.Repository
{
    public interface ILibroRepository
    {
        Task<Libro> Add(Libro libro);
        Task<IEnumerable<Libro>> GetAll();  
        Task<Libro?> GetById(int id);
        Task<bool> Update(Libro libro);        
        Task<bool> Delete(int id);
    }
}
