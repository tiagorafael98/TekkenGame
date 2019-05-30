using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TekkenGame.Models
{
    public class Utilizadores
    {
        public Utilizadores()
        {
            ListaDeComentarios = new HashSet<Comentarios>();
        }

        [Key]
        public int ID { get; set; }

        public string UserName { get; set; }

        public string NomeCompleto { get; set; }

        public string Email { get; set; }

        public string ContactoTelefonico { get; set; }

        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
    }
}