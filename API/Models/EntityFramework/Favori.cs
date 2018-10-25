using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.EntityFramework
{
    [Table("T_J_FAVORI_FAV")]
    public class Favori
    {
        [Column("CPT_ID")]
        public int CompteId { get; set; }
        [Column("FLM_ID")]
        public int FilmId { get; set; }

        [ForeignKey("CompteId")]
        [InverseProperty("FavorisCompte")]
        public Compte CompteFavori { get; set; }
        [ForeignKey("FilmId")]
        [InverseProperty("FavorisFilm")]
        public Film FilmFavori { get; set; }
    }
}
