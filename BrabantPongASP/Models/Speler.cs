using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrabantPongASP.Models
{
    public class Speler
    {
        [Key]
        public int SpelerId { get; set; }

        [Required]
        public string SpelerVoornaam { get; set; }

        [Required]
        public string SpelerAchternaam { get; set; }

        public int ClubId { get; set; }

        [ForeignKey("ClubId")]
        public Club Club { get; set; }

        public int RankingId { get; set; }

        [ForeignKey("RankingId")]
        public Ranking Ranking { get; set; }

        public bool IsDeleted { get; set; }
    }
}
