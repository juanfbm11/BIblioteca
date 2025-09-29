
using ApiBiblioteca.Repository.Implements;
using ApiBiblioteca.Repository.Repository;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ApiBiblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IDbConnection>(options =>
            {
                var connect = builder.Configuration.GetConnectionString("SqlConnection");
                var con = new SqlConnection(connect);
                return con;
            });

            builder.Services.AddTransient<ILibroRepository, LibroRepository>();
            builder.Services.AddTransient<ILibroQueries, LibroQueries>();
            builder.Services.AddTransient<ITecnicoRepository, TecnicoRepository>();
            builder.Services.AddTransient<ITecnicoQueries, TecnicoQueries>();
            builder.Services.AddTransient<IMantenimientoQueries, MantenimientoQueries>();
            builder.Services.AddTransient<IMantenimientoRepository, MantenimientoRepository>();

            builder.Services.AddSwaggerGen();
            
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
