using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class works_on
    {
        public int? Hours { get; set; }

        [ForeignKey("Project")]
        public int? Pnum { get; set; }
        public project? Project { get; set; }
        [ForeignKey("Employee")]
        public int? ESSN { get; set; }
        public employee? Employee { get; set; }
    }
}
