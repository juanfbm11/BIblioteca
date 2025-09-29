using ApiBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repository.Repository
{
    public interface ITecnicoQueries
    {
        Task<IEnumerable<Tecnico>> GetAll();
    }
}