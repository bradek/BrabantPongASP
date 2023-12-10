using System.ComponentModel.DataAnnotations;
namespace BrabantPongASP.Models
{
    public class Toernooi
    {
        [Key]
        public int ToernooiId { get; set; }

        [Required]
        public string ToernooiNaam { get; set; }

        public ICollection<ToernooiScheidsrechter> Scheidsrechters { get; set; }

    }
}
