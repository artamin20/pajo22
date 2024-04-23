using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pajo22.Models
{
    public enum ProductStatus
    {
        Active,
        Delisted,
        Inactive
    }

    public class ProductModels
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "قیمت")]
        public decimal Price { get; set; }

        [Display(Name = "عکس")]
        public string? Image { get; set; }

        [Display(Name = "توضیحات")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "رنگ")]
        public string? Color { get; set; }

        public int SubgroupId { get; set; }

        // Navigation property to represent the relationship between ProductModels and SubgroupModels
        public virtual SubgroupModels? Subgroup { get; set; }

        // Navigation property to access related AttributeValues
        public virtual ICollection<AttributeValues>? AttributeValues { get; set; }

        // Enum property to indicate status
        public ProductStatus? Status { get; set; } = ProductStatus.Active;
    }
}