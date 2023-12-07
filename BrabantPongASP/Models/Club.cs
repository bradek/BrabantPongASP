using System.ComponentModel.DataAnnotations;

namespace BrabantPongASP.Models
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }

        [Required]
        public string ClubNaam { get; set; }

        public bool IsDeleted { get; set; }

    }
}
