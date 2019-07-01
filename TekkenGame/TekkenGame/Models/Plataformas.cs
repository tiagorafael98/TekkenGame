using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TekkenGame.Models;

namespace TekkenGame.Models
{
    public class Plataformas
    {
        public Plataformas()
        {
            ListaDeJogos = new HashSet<Jogos>();
        }

        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Logotipo { get; set; }

        public virtual ICollection<Jogos> ListaDeJogos { get; set; }

    }
}