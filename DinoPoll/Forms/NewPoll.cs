using System.ComponentModel.DataAnnotations;

namespace DinoPoll.Forms
{
    public class NewPoll : IValidatableObject
    {
        [Required]
        public string Question { get; set; }

        [Required]
        [Range(2, 255)]
        public int Participants { get; set; } = 2;

        public List<NewOption> Options { get; set; } = new List<NewOption>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Options.Count == 0)
            {
                yield return new ValidationResult("Provide at least one option.", new[] { nameof(Options) });
            }
        }
    }
}
