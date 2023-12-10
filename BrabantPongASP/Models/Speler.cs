using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrabantPongASP.Models
{
    public class Speler
    {
        /*Ik gebruik de SpelerId als de Primary Key van de SpelerId tabel.*/
        [Key]
        public int SpelerId { get; set; }
        
        /*Ik wil dat zowel SpelerVoornaam als SpelerAchternaam
         niet nullable zijn.
        Daarom zet ik ze op 'Required'.*/
        [Required]
        public string SpelerVoornaam { get; set; }

        [Required]
        public string SpelerAchternaam { get; set; }

        /*De ClubId en RankingId wordt als referentie gebruikt naar Club en Ranking.*/
        public int ClubId { get; set; }

        /*Ik gebruik ClubId als ForeignKey.
         Hiervoor gebruik ik de ClubId van Club.
        Ik doe hetzelfde voor Ranking.*/
        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public int RankingId { get; set; }

        [ForeignKey("RankingId")]
        public Ranking Ranking { get; set; }

        /*IsDeleted is een property die ik gebruik om na te gaan of 
         * een bepaald item 'verwijderd' is. 
         * Ik gebruik deze als een boolean.
         * Als IsDeleted op true staat, wordt dit item verborgen.*/
        public bool IsDeleted { get; set; }
    }
}
