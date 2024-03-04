using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog_AP.Models
{
    public class Falcuty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("falcuty_id")]
        public int? post_id { get; set; }

        [Column("falcuty_name")]
        [Required]
        public string? user_id { get; set; }
    }
}
