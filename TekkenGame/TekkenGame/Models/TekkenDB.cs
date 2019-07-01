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
        public System.Data.Entity.DbSet<TekkenGame.Models.Comentarios> Comentarios { get; set; }

        public System.Data.Entity.DbSet<TekkenGame.Models.Jogos> Jogos { get; set; }

        public System.Data.Entity.DbSet<TekkenGame.Models.Utilizadores> Utilizadores { get; set; }
        //public TekkenDB() : base("TekkenDBConnectionString") { }

        // vamos colocar, aqui, as instruções relativas às tabelas do 'negócio'
        // descrever os nomes das tabelas na Base de Dados


    }
}