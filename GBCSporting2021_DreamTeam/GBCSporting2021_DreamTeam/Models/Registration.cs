using System;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_DreamTeam.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }
        [Required(ErrorMessage = "Please select a customer.")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required(ErrorMessage = "Please select a product.")]
        public int ProductId { get; set; }
        public Products Product { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; } = DateTime.Now.Date;

    }
}
