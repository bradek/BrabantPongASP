using System.ComponentModel.DataAnnotations;

namespace BrabantPongASP.Models
{
    public class Club
    {
        /*Ik gebruik de ClubId als de Primary Key van de Club tabel.*/
        [Key]
        public int ClubId { get; set; }

        /*Ik wil niet dat ClubNaam nullable is, 
         dus maak ik het verplicht deze niet leeg te laten zijn.*/

        [Required]
        public string ClubNaam { get; set; }

        /*IsDeleted is een property die ik gebruik om na te gaan of
         een bepaald item 'verwijderd' is. 
        Ik gebruik deze als een boolean.
        Als IsDeleted op true staat, wordt dit item verborgen.*/

        public bool IsDeleted { get; set; }

    }
}
