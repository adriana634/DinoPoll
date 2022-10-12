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

        [ValidateComplexType]
        public List<NewOption> Options { get; set; } = new List<NewOption>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Options.Count < 2)
            {
                yield return new ValidationResult("Provide at least two options.", new[] { nameof(Options) });
            }
        }
    }
}
