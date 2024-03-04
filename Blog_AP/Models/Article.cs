using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog_AP.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("post_id")]
        public int? post_id { get; set; }

        [Column("post_user_id")]
        [Required]
        public int? user_id { get; set; }

        [Column("post_accept_by")]
        [Required]
        public string? admin { get; set; }

        [Column("post_falcuty")]
        [Required]
        public int? falcuty_id { get; set; }
    }
}
