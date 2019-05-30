using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TekkenGame.Models
{
    public class Jogos
    {
        public Jogos()
        {
            ListaDeComentarios = new HashSet<Comentarios>();
        }

        [Key]
        public int ID { get; set; }

        public string Titulo { get; set; }

        public string Logotipo { get; set; }

        public string Resumo { get; set; }

        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
        public virtual ICollection<Personagens> ListaDePersonagens { get; set; }
    }
}