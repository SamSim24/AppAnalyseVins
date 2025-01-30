using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace TP2_POO2.Model
{
    internal class TP2_POO2Context: DbContext
    {
        public DbSet<Model.Client> Clients { get; set; }
        public DbSet<Model.Oenologue> Oenologues { get; set; }
        public DbSet<Model.Vin> Vins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOpionsBuilder)
        {
            string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            string database_name = "TP2_POO2DB";
            dbContextOpionsBuilder.UseSqlServer($"{connection_string};Database={database_name};") ;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Oenologue>().HasData(
                new Model.Oenologue() { oenologueId = "1", AppMDP = "1234", nom = "Samuel", prenom = "Samuel", dateNaissance = "2003/10/24", ville = "Lévis", province = "Québec", pays = "Canada", adresse = "12", civilite = "Monsieur"}
                );
            modelBuilder.Entity<Model.Client>().HasData(
                new Model.Client() { clientId = 1, oenologueId = "1" ,nom = "Samuel", prenom = "Samuel", dateNaissance= "2003/10/24", ville = "Lévis", province = "Québec", pays = "Canada", adresse = "12", civilite = "Monsieur"}
                );
            modelBuilder.Entity<Model.Vin>().HasData(
                new Model.Vin() { vinId = 1, clientId = 1, alcool = "9.8", sulphate = "0.53", acideCitrique = "0.25", acideVolatile = "0.6"}
                );
        }
    }
}
