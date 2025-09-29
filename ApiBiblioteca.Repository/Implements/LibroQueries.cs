using ApiBiblioteca.Models;
using ApiBiblioteca.Repository.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repository.Implements
{
    public class LibroQueries : ILibroQueries
    {
        private readonly IDbConnection _db;

        public LibroQueries(IDbConnection db)
        {
            _db= db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Libro>> Getall()
        {
            try
            {
                string sql = "SELECT * FROM Libro";
                var rs = await _db.QueryAsync<Libro>(sql);
                return rs;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
