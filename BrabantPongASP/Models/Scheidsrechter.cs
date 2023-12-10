using System.ComponentModel.DataAnnotations;
namespace BrabantPongASP.Models
{
    public class Scheidsrechter
    {
        [Key]

        public int ScheidsrechterId { get; set; }
        [Required]
        public string ScheidsrechterNaam { get; set; }


        public ICollection<ToernooiScheidsrechter> Toernooien { get; set; }

    }
}
