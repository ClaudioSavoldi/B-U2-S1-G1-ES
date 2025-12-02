using System.ComponentModel.DataAnnotations;

namespace B_U2_S1_G1_ES.ViewModels
{
    public class AddBookViewModel
    {

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

        // Lista generi per la select
        public List<string> Genres { get; set; } = new()
    {
        "Epic-Fantasy",
        "Dragon-Fantasy",
        "High-Fantasy",
        "Dark-Fantasy",
        "Magic-Fantasy"
    };

    }
}
