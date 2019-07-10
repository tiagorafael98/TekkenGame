using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TekkenGame.Models
{
    public class Personagens
    {
        public Personagens()
        {
            ListaDeComentarios = new HashSet<Comentarios>();
            ListaDeJogos = new HashSet<Jogos>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Origem { get; set; }
        [Required]
        public string TipoLuta { get; set; }
        [Required]
        public string Fotografia { get; set; }
        
        public string Biografia { get; set; }

        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
        public virtual ICollection<Jogos> ListaDeJogos { get; set; }
    }
}