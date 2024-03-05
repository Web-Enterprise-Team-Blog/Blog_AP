using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blog_AP.Models
{
    public class Faculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("faculty_id")]
        public int? FacultyId { get; set; }

        [Column("faculty_name")]
        [Required]
        public string? FacultyName { get; set; }
    }
}
