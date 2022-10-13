using System.ComponentModel.DataAnnotations;

namespace DinoPoll.Forms
{
    public class NewOption
    {
        [Required]
        public string Text { get; set; }

        [Display(Name = "Wikipedia URL")]
        [RegularExpression("^https:\\/\\/en.wikipedia.org\\/wiki\\/.+$", ErrorMessage = "Wikipedia URL is required.")]
        public string? WikipediaURL { get; set; }
    }
}
