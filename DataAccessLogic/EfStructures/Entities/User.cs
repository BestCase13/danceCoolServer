using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLogic.EfStructures.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(128)]
        public int FirstName { get; set; }
        [Required]
        [StringLength(128)]
        public int LastName { get; set; }
        [StringLength(17)]
        public string PhoneNumber { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        [InverseProperty("Users")]
        public Role Role { get; set; }
    }
}
