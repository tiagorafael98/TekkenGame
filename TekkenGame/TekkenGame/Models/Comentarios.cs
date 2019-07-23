using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TekkenGame.Models
{
    public class Comentarios
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Texto { get; set; }

        public DateTime DataComentario { get; set; }

        [ForeignKey("Jogo")]
        public int JogoFK { get; set; }
        public virtual Jogos Jogo { get; set; }

        [ForeignKey("Utilizadores")]
        public int UtilizadoresFK { get; set; }
        public virtual Utilizadores Utilizadores { get; set; }
    }
}