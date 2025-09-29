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
       public class LibroRepository : ILibroRepository
       {

        private readonly IDbConnection _db;

        public LibroRepository(IDbConnection db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public async Task<Libro> Add(Libro libro)
        {
            try
            {
                libro.Id = await _db.InsertAsync(libro);
                return libro;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al insertar libro: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<Libro>> GetAll()
        {
            return await _db.GetAllAsync<Libro>();
        }

        public async Task<Libro?>GetById(int Id)
        {
            return await _db.GetAsync<Libro>(Id);
        }
       
        public async Task<bool>Update(Libro libro)
        {
            return await _db.UpdateAsync(libro);
        }

        public async Task<bool>Delete(int id)
        {
            var libro = await GetById(id);
            if (libro==null)
                return false;

            return await _db.DeleteAsync(libro);
            
        }

        
    }
}
