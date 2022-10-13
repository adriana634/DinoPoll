using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DinoPoll.Data
{
    [Table("Options")]
    public class Option
    {
        [Key]
        public int OptionId { get; set; }

        [Required]
        public Guid PollId { get; set; }

        [Required]
        public string Text { get; set; }

        [RegularExpression("^https:\\/\\/en.wikipedia.org\\/wiki\\/.+$")]
        public string? WikipediaURL { get; set; }

        [Required]
        public byte Votes { get; set; }

        [Required]
        public byte Order { get; set; }
    }
}
