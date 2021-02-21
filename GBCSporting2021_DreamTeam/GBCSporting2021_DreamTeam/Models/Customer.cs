using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_DreamTeam.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter a first name.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a last name.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter a city.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please enter a state or province.")]
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a postal code.")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please enter a country.")]
        public string CountryId { get; set; }
        public Country Country { get;set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FullName =>
            FirstName + " " + LastName;
        public string Slug =>
            FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();

    }
}
