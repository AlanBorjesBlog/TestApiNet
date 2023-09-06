using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestApi.Models;

namespace TestApi
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Mascota>? Mascotas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mascota>().HasData(
                new Mascota()
                {
                    Id = 1,
                    Nombre = "Selenium",
                    Especie = "Gato",
                    Raza = "N/A",
                    Peso = 5.5F,
                    FechaNacimiento = new DateTime()
                },
                new Mascota()
                {
                    Id = 2,
                    Nombre = "Risopus",
                    Especie = "Perro",
                    Raza = "Labrador",
                    Peso = 15.5F,
                    FechaNacimiento = new DateTime()
                },
                new Mascota()
                {
                    Id = 3,
                    Nombre = "Kira",
                    Especie = "Perro",
                    Raza = "Dalmata",
                    Peso = 20.5F,
                    FechaNacimiento = new DateTime()
                }
            );
        }
    }
}
