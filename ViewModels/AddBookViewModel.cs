using B_U2_S1_G1_ES.Models.Entity;

using System.ComponentModel.DataAnnotations;

namespace B_U2_S1_G1_ES.ViewModels
{
    public class AddBookViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        [Url]
        public string CoverImage { get; set; }

        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public Guid GenreId { get; set; }

        public List<Genre> Genres { get; set; } =new List<Genre>();

        public ICollection<RentManagement> RentManagements { get; set; }
    }
}
