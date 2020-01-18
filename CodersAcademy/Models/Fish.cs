using System.ComponentModel.DataAnnotations;

namespace Underwater.Models
{
    public class Fish
    {
        [Key]
        public int FishId { get; set; }

        [Display(Name = "Fish Name:")]
        [Required(ErrorMessage = "Enter a name")]
        public string Name { get; set; }

        [Display(Name = "Scientific Name:")]
        [Required(ErrorMessage = "Enter a scientific name")]
        public string ScientificName { get; set; }

        [Display(Name = "Common Name:")]
        public string CommonName { get; set; }

        public byte[] PhotoAvatar { get; set; }

        public string ImageName { get; set; }

        public byte[] PhotoFile { get; set; }

        public string ImageMimeType { get; set; }

        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Please select an aquarium")]
        public int AquariumId { get; set; }

        public virtual Aquarium Aquarium { get; set; }
    }
}
