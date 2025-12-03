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
        public bool IsAvailable { get; set; }
        [Required]
        [Url]
        public string CoverImage { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
      
        public ICollection<RentManagement> RentManagements { get; set; }
}
}
