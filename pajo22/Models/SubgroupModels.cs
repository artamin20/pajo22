using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pajo22.Models
{
    public class SubgroupModels
    {
        public int Id { get; set; }

        [Display(Name = "نام زیرگروه")]
        public string Name { get; set; }

        public int GroupID { get; set; }

        // اتصال به گروه
        [ForeignKey("GroupID")]
        public virtual GroupModels? GroupModels { get; set; }

        public virtual ICollection<ProductModels>? Product { get; set; }

        
    }
}
