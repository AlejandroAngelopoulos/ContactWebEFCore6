using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactWebModels
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="First Name")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_FIRST_NAME_LENGTH)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_LAST_NAME_LENGHT)]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_EMAIL_LENGTH)]
        [EmailAddress (ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display (Name = "Mobile Phone")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_PHONE_LENGHT)]
        public string PhonePrimary { get; set; }

        [Display(Name = "Home Phone")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_PHONE_LENGHT)]
        public string PhoneSecondary { get; set; }

        [Display(Name = "Address1")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress1 { get; set; }

        [Display(Name = "Address2")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_STREET_ADDRESS_LENGTH)]
        public string StreetAddress2 { get; set; }

        [Display(Name = "City")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_CITY_LENGTH)]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        [Required]
        [StringLength(ContactManagerConstants.MAX_ZIP_CODE_LENGHT, MinimumLength = ContactManagerConstants.MIN_ZIP_CODE_LENGTH)]
        public string Zip { get; set; }

        [Display(Name = "State")]
        [Required]
        public int StateId { get; set; }

        public virtual State State { get; set; }

        [Required]
        public string UserId { get; set; }

        [Display (Name ="Full Name")]
        public string FriendlyName => $"{FirstName},{LastName}";

        [Display(Name = "Full Address")]
        public string FriendlyAddress => State is null ? "" : string.IsNullOrWhiteSpace(StreetAddress1) ? $"{City},{State.Abbreviation},{Zip}" :
                                         string.IsNullOrWhiteSpace(StreetAddress2) ?
                                                $"{StreetAddress1},{City},{State.Abbreviation},{Zip}":
                                                $"{StreetAddress1},{StreetAddress2},{City},{State.Abbreviation},{Zip}";




    }
}
