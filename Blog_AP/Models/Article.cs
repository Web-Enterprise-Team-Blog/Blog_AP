using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog_AP.Models
{
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("article_id")]
        public int? article_id { get; set; }

        [Column("article_user_id")]
        [Required]
        public int? user_id { get; set; }

        [Column("article_accept_by")]
        [Required]
        public string? admin { get; set; }

        [Column("article_falcuty")]
        [Required]
        public int? falcuty_id { get; set; }
    }
}
