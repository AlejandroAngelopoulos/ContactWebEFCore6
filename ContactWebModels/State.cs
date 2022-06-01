using System.ComponentModel.DataAnnotations;

namespace ContactWebModels
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "State")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_STATE_NAME_LENGTH)]
        public string Name { get; set; }

        [Required]
        [StringLength(ContactManagerConstants.MAX_STATE_ABBR_LENGTH)]
        public string Abbreviation { get; set; } 

    }
}
