using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pajo22.Models
{
    public enum GroupStatus
    {
        Active,
        Delisted,
        Inactive
    }

    public class GroupModels
    {
        public int Id { get; set; }

        [Display(Name = "نام گروه")]
        public string Name { get; set; }

        public virtual ICollection<SubgroupModels>? Subgroups { get; set; }

        // Enum property to indicate status
        public GroupStatus Status { get; set; } = GroupStatus.Active;
    }
}
