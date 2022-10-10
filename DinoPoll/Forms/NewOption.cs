using System.ComponentModel.DataAnnotations;

namespace DinoPoll.Forms
{
    public class NewOption
    {
        [Required]
        public string Text { get; set; }

        [Required]
        [Url]
        [RegularExpression("^https:\\/\\/en.wikipedia.org\\/wiki\\/.+$")]
        public string WikipediaURL { get; set; }
    }
}
