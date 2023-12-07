using System.ComponentModel.DataAnnotations;

namespace BrabantPongASP.Models
{
    public class Ranking
    {
        [Key]
        public int RankingId { get; set; }

        [Required]
        public string RankingNaam { get; set; }

        public bool IsDeleted { get; set; }
    }
}
