using System.ComponentModel.DataAnnotations;

namespace B_U2_S1_G1_ES.Models.Entity
{
    public class Genre
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
       
        public ICollection<Book> Books { get; set; }


    }
}
