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
    public class MantenimientoQueries : IMantenimientoQueries
    {
        private readonly IDbConnection _db;

        public MantenimientoQueries(IDbConnection db)
        {
            _db=db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Mantenimiento>> Getall()
        {
            try
            {
                string sql = "SELECT * FROM Mantenimiento";
                var rs = await _db.QueryAsync<Mantenimiento>(sql);
                return rs;

            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
