using B_U2_S1_G1_ES.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace B_U2_S1_G1_ES.ViewModels
{
    public class GenreViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string? Description { get; set; } 

    }
}
