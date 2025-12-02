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

        //Funzione save
        public bool Save()
        {
            // save changes
            if (this._context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        //funzione per creare un libro
        public bool Create(Book book)
        {
            
            this._context.Books.Add(book);
           
            
            return this.Save();
        }

        //prendere tutti i libri
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        //prendere un libro by id
        public Book GetBookById(Guid Id)
        {
         
            return this._context.Books.FirstOrDefault(b => b.Id == Id);
        }



        //update per ledit dei book
        public bool Update(Book book)
        {
      
            var existingBook = GetBookById(book.Id);

            if (existingBook is null)
                return false;

    
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Genre = book.Genre;
            existingBook.IsAvailable = book.IsAvailable;
            existingBook.CoverImage = book.CoverImage;

      
            return _context.SaveChanges() > 0;

        }


        //delete
        public bool Delete(Guid id)
        {
            var bookToDelete = GetBookById(id);
            if (bookToDelete is not null)
            {
                this._context.Books.Remove(bookToDelete);
                return this.Save();
            }
            return false;
        }





    }
}
