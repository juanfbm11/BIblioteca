using ApiBiblioteca.Models;
using ApiBiblioteca.Repository.Repository;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repository.Implements
{
    public class TecnicoQueries : ITecnicoQueries
    {
        private readonly IDbConnection _db;

        public TecnicoQueries(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Tecnico>> GetAll()
        {
           
            return await _db.GetAllAsync<Tecnico>();
        }

        public async Task<Tecnico?> GetById(int id)
        {
            return await _db.GetAsync<Tecnico>(id);
        }
    }
}
