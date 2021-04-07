using System;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_DreamTeam.Models
{
    public class Incident
    {
        [Key]
        public int IncidentId { get; set; }
        public Customer Customer { get; set; }
        [Required(ErrorMessage = "Please select a customer.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please seelct a product.")]
        public int ProductId { get; set; }
        public Products Product { get; set; }
        [Required(ErrorMessage = "Please enter a incident name.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a incident description.")]
        public string Description { get; set; }
        public int? TechnicianId  { get; set; }
        public Technician Technician { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Open { get; set; } = null;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Close { get; set; } = null;
        public string Slug =>
           Title?.Replace(' ', '-').ToLower() + '-' + Description?.Replace(' ', '-').ToLower();

    }
}
