using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLogic.EfStructures.Entities
{
    public partial class Role
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<User> Users { get; set; }
    }
}