using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog_AP.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int? Id { get; set; }

        [Column("user_name")]
        [Required]
        public string? UserName { get; set; }

        [Column("user_email")]
        [Required]
        public string? UserEmail { get; set;}

        [Column("passoword")]
        [Required]
        public string? UserPassword { get; set;}
    }
}
