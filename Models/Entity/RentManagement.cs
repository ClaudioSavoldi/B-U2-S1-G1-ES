namespace B_U2_S1_G1_ES.Models.Entity
{
    public class RentManagement
    {

        public Guid Id { get; set; }
        public DateTime RentAt { get; set; }
        public DateTime RentExpiration { get; set; }
        public Guid UserId { get; set; }  
        public User User { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
