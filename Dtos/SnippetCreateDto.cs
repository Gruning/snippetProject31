using System.ComponentModel.DataAnnotations;

namespace SnippetProject31.Dtos
{
    public class SnippetCreateDto
    {
        [Required][MaxLength(200)] public string HowTo { get; set; }
        [Required] public string Line { get; set; }
        [Required]public string Platform { get; set; }

    }
}