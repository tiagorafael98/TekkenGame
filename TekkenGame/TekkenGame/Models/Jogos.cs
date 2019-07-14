using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ListaDePersonagens = new HashSet<Personagens>();
            ListaDePlataformas = new HashSet<Plataformas>();
        }

        [Key]
        public int ID { get; set; }
        
        [DisplayName("Título")]
        public string Titulo { get; set; }
       
        public string Logotipo { get; set; }
        
        public string Fotografia { get; set; }
       
        public string Resumo { get; set; }

        [DisplayName("Lista de comentários")]
        public virtual ICollection<Comentarios> ListaDeComentarios { get; set; }
        [DisplayName("Lista de personagens")]
        public virtual ICollection<Personagens> ListaDePersonagens { get; set; }
        [DisplayName("Lista de plataformas")]
        public virtual ICollection<Plataformas> ListaDePlataformas { get; set; }
    }
}