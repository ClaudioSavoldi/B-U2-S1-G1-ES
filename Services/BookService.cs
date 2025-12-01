using B_U2_S1_G1_ES.Models.Entity;

namespace B_U2_S1_G1_ES.Services
{
    public class BookService
    {

        private readonly ApplicationDbContext _context;
        public BookService(ApplicationDbContext context)
        {
            _context = context;

        }

        public bool Create(Book book)
        {
            // insert product into database
            this._context.Books.Add(book);
            // save changes
            if (this._context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }


    }
}
