using ApiBiblioteca.Models;
using ApiBiblioteca.Repository.Repository;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace ApiBiblioteca.Repository.Implements
{
    public class TecnicoRepository : ITecnicoRepository
    {
        private readonly IDbConnection _db;

        public TecnicoRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public async Task<IEnumerable<Tecnico>> GetAll()
        {
            try
            {
                return await _db.GetAllAsync<Tecnico>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los técnicos: {ex.Message}", ex);
            }
        }

        public async Task<Tecnico> GetById(int id)
        {
            try
            {
                return await _db.GetAsync<Tecnico>(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener técnico por Id: {ex.Message}", ex);
            }
        }

        public async Task<Tecnico> Add(Tecnico tecnico)
        {
            try
            {
                tecnico.Id = (int)await _db.InsertAsync(tecnico);
                return tecnico;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar técnico: {ex.Message}", ex);
            }
        }

        public async Task<Tecnico?> Update(int id, Tecnico tecnico)
        {
            try
            {
                var existente = await _db.GetAsync<Tecnico>(id);
                if (existente == null)
                    return null;

                tecnico.Id = id; 
                var actualizado = await _db.UpdateAsync(tecnico);

                return actualizado ? tecnico : null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al actualizar técnico: {ex.Message}", ex);
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var tecnico = await _db.GetAsync<Tecnico>(id);
                if (tecnico == null)
                    return false;

                return await _db.DeleteAsync(tecnico);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar técnico: {ex.Message}", ex);
            }
        }
    }
}