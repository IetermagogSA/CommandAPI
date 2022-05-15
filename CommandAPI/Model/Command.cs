using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Model
{
    public class Command
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [MaxLength(250)]
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string Platform { get; set; }
        [Required]
        public string CommandLine { get; set; }
    }
}
