using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_DreamTeam.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }
        [Required(ErrorMessage = "Please enter a technician name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string Phone { get; set; }
        public string Slug =>
            Name?.Replace(' ', '-').ToLower() + '-' + Email?.Replace(' ', '-').ToLower();
    }
}
