using ApiBiblioteca.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repository.Repository
{
    public interface ITecnicoRepository
    {
        Task<IEnumerable<Tecnico>> GetAll();
        Task<Tecnico> GetById(int id);
        Task<Tecnico> Add(Tecnico tecnico);
        Task<Tecnico?> Update(int id, Tecnico tecnico);
        Task<bool> Delete(int id);
    }
}