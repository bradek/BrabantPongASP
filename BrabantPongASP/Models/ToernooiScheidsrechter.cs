using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrabantPongASP.Models
{
    public class ToernooiScheidsrechter
    {
        [Key]
        public int ToernooiScheidsrechterId { get; set; }

        public int ToernooiId { get; set; }
        public Toernooi Toernooi { get; set; }

        public int ScheidsrechterId { get; set; }
        public Scheidsrechter Scheidsrechter { get; set; }
    }
}
