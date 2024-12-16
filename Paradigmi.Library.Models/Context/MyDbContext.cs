using Microsoft.EntityFrameworkCore;
using Paradigmi.Library.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paradigmi.Library.Models.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(
                "data source=PIERSY_PC;Initial catalog=Library;User Id=CristianoRonaldo;Password=Cristiano!;TrustServerCertificate=True",

            sqlServerOptions => sqlServerOptions.EnableRetryOnFailure(
                maxRetryCount: 5,                // Numero massimo di tentativi
                maxRetryDelay: TimeSpan.FromSeconds(10), // Ritardo massimo tra i tentativi
                errorNumbersToAdd: null         // Errori specifici da considerare (opzionale)
            )
        );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // prende tutte le classi dentro models che implementano l'interfaccia per la configurzione
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
