using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pajo22.Models
{
    public class ProductModels
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        public string? Name { get; set; }

        [Display(Name = "قیمت")]
        public int? Price { get; set; }

        [Display(Name = "عکس")]
        public string? Image { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "رنگ")]
        public string? Color { get; set; }

        public int SubgroupId { get; set; }

        // ارتباط بین محصولات و زیر گروه
        [ForeignKey("SubgroupId")]
        public virtual SubgroupModels? Subgroup { get; set; }
    }
 

}


