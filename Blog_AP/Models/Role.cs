using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog_AP.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("role_id")]
        public int? Id { get; set; }

        [Column("role_name")]
        [Required]
        public string? RoleName { get; set; }

    }
}
