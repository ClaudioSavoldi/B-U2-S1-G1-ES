using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace B_U2_S1_G1_ES.Models.Entity
{
    public class User
    {

        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public ICollection<RentManagement> RentManagements { get; set; }
    }
}
