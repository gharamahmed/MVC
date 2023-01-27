using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC2.Models
{
    public class project
    {
        [Key]
        public int Number { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? Location { get; set; }
        public List<works_on>? works_Ons { get; set; }

        public department?Department { get; set; }
        [ForeignKey("Department")]
        public int ? DepartmentId { get; set; }
    }
}
