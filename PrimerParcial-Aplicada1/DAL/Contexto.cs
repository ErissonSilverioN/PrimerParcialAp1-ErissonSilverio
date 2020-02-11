using Microsoft.EntityFrameworkCore;
using PrimerParcial_Aplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimerParcial_Aplicada1.DAL
{
    public class Contexto : DbContext

    {
        public DbSet<Articulos> articulos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=.\SqlExpress; Database=ArticulosDb; Trusted_Connection = True;");
        }
    }
}
