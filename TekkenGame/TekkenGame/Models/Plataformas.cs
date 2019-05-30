using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TekkenGame.Models
{
    public class Plataformas
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Logotipo { get; set; }
    }
}