using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Front.Models
{
    public class Film
    {
        public Film()
        {
            AvisFilm = new HashSet<Avis>();
            FavorisFilm = new HashSet<Favori>();
        }

      
        public int FilmId { get; set; }
    
        public string Titre { get; set; }
     
        public string Synopsis { get; set; }

        public DateTime DateParution { get; set; }

        public decimal Duree { get; set; }
      

        public string Genre { get; set; }
       

        public string UrlPhoto { get; set; }


        public ICollection<Avis> AvisFilm { get; set; }

        public ICollection<Favori> FavorisFilm { get; set; }
    }
}
