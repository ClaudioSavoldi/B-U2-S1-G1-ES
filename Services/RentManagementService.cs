using B_U2_S1_G1_ES.Models.Entity;

namespace B_U2_S1_G1_ES.Services
{
    public class RentManagementService
    {

        private readonly ApplicationDbContext _context;
        public RentManagementService(ApplicationDbContext context)
        {
            _context = context;
        }

    }
}
