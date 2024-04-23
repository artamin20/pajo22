using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pajo22.Models
{
    public class Attributes
    {
        [Key]
        public int AttributeID { get; set; }

        [Required]
        public string AttributeName { get; set; }

        // Navigation property to represent the relationship with SubgroupModels
        public int SubgroupId { get; set; }
        public virtual SubgroupModels? Subgroup { get; set; }

        // Navigation property to access related AttributeValues
        public virtual ICollection<AttributeValues>? AttributeValues { get; set; }
    }
}