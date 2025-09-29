using ApiBiblioteca.Models;
using ApiBiblioteca.Repository.Repository;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repository.Implements
{
    public class MantenimientoRepository : IMantenimientoRepository
    {
        private readonly IDbConnection _db;      


        public MantenimientoRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<Mantenimiento> Add(Mantenimiento mantenimiento)
        {
            if (mantenimiento == null) throw new ArgumentNullException(nameof(mantenimiento));
            var id = await _db.InsertAsync(mantenimiento);
            mantenimiento.Id = (int)id;
            return mantenimiento;
        }

        public async Task<bool> Delete(int Id)
        {
           var rs = await GetById(Id);
            if (rs == null) 
                return false;
            return await _db.DeleteAsync(rs);
        }

        public async Task<IEnumerable<Mantenimiento>> GetAll()
        {
            return await _db.GetAllAsync<Mantenimiento>();
        }

        public async Task<Mantenimiento?> GetById(int id)
        {
            return await _db.GetAsync<Mantenimiento>(id);
        }

        public async Task<IEnumerable<Mantenimiento>> GetByLibro(int libroId)
        {
            var sql = "SELECT * FROM Mantenimiento WHERE LibroId = @LibroId";
            return await _db.QueryAsync<Mantenimiento>(sql, new { LibroId = libroId });
        }

        public async Task<IEnumerable<Mantenimiento>> GetByTecnico(int tecnicoId)
        {
            var sql = "SELECT * FROM Mantenimiento WHERE TecnicoId = @TecnicoId";
            return await _db.QueryAsync<Mantenimiento>(sql, new { TecnicoId = tecnicoId });
        }

        public async Task<bool> Update(Mantenimiento mantenimiento)
        {
            return await _db.UpdateAsync(mantenimiento);
        }
    }
}