using System.ComponentModel.DataAnnotations;

namespace B_U2_S1_G1_ES.Models.Entity
{
    public class Book
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public string CoverImage { get; set; }



    }
}
