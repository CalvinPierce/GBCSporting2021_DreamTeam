using GBCSporting2021_DreamTeam.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_DreamTeam.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [Range(1, 51,
            ErrorMessage = "First name must be between 1 and 51 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [Range(1, 51,
            ErrorMessage = "Last name must be between 1 and 51 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a address.")]
        [Range(1, 51,
            ErrorMessage = "Address must be between 1 and 51 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter a city.")]
        [Range(1, 51,
            ErrorMessage = "City must be between 1 and 51 characters.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state or province.")]
        [Range(1, 51,
            ErrorMessage = "State must be between 1 and 51 characters.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a postal code.")]
        [Range(1, 21,
            ErrorMessage = "Postal must be between 1 and 21 characters.")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please select a valid country.")]
        [GreaterThan(0, ErrorMessage = "Please Select a valid Country")]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        [Range(1, 51,
            ErrorMessage = "Email must be between 1 and 51 characters.")]
        [Remote("CheckEmail", "Validation", AdditionalFields = "CustomerId", ErrorMessage = "Email already in use")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Phone number must be in (999) 999-9999 format.")]
        public string Phone { get; set; }
        public string FullName =>
            FirstName + " " + LastName;
        public string Slug =>
            FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();

    }
}
