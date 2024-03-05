using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Blog_AP.Models
{
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public override string Id { get; set; }

        [Column("user_name")]
        [Required]
        public string? UserName { get; set; }

        [Column("user_email")]
        [Required]
        public string UserEmail { get; set;}

        [Column("password")]
        [Required]
        public string UserPassword { get; set;}

        public Role? Role { get; set; }

        public Faculty? Faculty { get; set; }
    }
}
