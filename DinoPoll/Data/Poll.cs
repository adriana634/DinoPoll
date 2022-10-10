using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DinoPoll.Data
{
    public class Poll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PollId { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        [Range(1, 255)]
        public byte Participants { get; set; }

        public ICollection<Option> Options { get; set; }
    }
}
