using System.ComponentModel.DataAnnotations;

namespace BrabantPongASP.Models
{
    public class Ranking
    {
        /*Ik gebruik de RankingId als de Primary Key van de Ranking tabel.*/
        [Key]
        public int RankingId { get; set; }

        [Required]
        public string RankingNaam { get; set; }

        /*IsDeleted is een property die ik gebruik om na te gaan of 
         * een bepaald item 'verwijderd' is. 
         * Ik gebruik deze als een boolean.
         * Als IsDeleted op true staat, wordt dit item verborgen.*/
        public bool IsDeleted { get; set; }
    }
}
