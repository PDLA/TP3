using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Front.Models
{

    public class Favori
    {
    
        public int CompteId { get; set; }
       
        public int FilmId { get; set; }

  
        public Compte CompteFavori { get; set; }
       
        public Film FilmFavori { get; set; }
    }
}
