using System;
using System.ComponentModel.DataAnnotations;

namespace GBCSporting2021_DreamTeam.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please select a product code.")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "Please enter a product name.")]   
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a price.")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please enter a release date.")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now.Date;
        public string Slug =>
            ProductCode?.Replace(' ', '-').ToLower() + '-' + Name?.Replace(' ', '-').ToLower();
    }
}
