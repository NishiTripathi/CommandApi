using System.ComponentModel.DataAnnotations;

namespace Commander.Dto
{
    public class CommandReadDto
    {
        public int Id { get; set; }
        [Required]
        public string HowTo {get;set;}
        [Required]
        public string Line {get;set;}
    }
    
}
    