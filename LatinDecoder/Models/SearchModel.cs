using System.ComponentModel.DataAnnotations;

namespace LatinDecoder.Models
{
    public class SearchModel
    {
        [Required(ErrorMessage = "Please enter a search term.")]
        [MinLength(2, ErrorMessage = "Please enter 2 or more characters.")]
        public string SearchTerm { get; set; }
    }
}
