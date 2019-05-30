using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace TekkenGame.Models
{
    public class TekkenDB : DbContext
    {
        public TekkenDB() : base("TekkenDBConnectionString") { }

        // vamos colocar, aqui, as instruções relativas às tabelas do 'negócio'
        // descrever os nomes das tabelas na Base de Dados
        public virtual DbSet<Jogos> Jogos { get; set; } // tabela Jogos
        public virtual DbSet<Personagens> Personagens { get; set; } // tabela Personagens
        public virtual DbSet<Plataformas> Plataformas { get; set; } // tabela Plataformas
        public virtual DbSet<Utilizadores> Utilizadores { get; set; } // tabela Utilizadores
        public virtual DbSet<Comentarios> Comentarios { get; set; } // tabela Comentarios


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}