using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class locations
    {
        [StringLength(100)]
        public string? location{ get; set; }
        [ForeignKey("Department")]
         public int? deptnum { get; set; }
        public department? Department { get; set; }
    }
}
