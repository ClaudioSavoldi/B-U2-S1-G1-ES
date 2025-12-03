using B_U2_S1_G1_ES.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace B_U2_S1_G1_ES.Services
{
    public class GenreService
    {

        private readonly ApplicationDbContext _context;
        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Save()
        {
            return await this._context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Create(Genre genre)
        {
            await this._context.Genres.AddAsync(genre);
            return await this.Save();
        }

        public async Task<List<Genre>> GetAllGenres()
        {
            return await _context.Genres.ToListAsync();
        }
        public Genre GetById(Guid id)
        {
            return  _context.Genres.FirstOrDefault(g => g.Id == id);
        }

        public async Task<bool> Update(Genre genre)
        {
            _context.Genres.Update(genre);
            return await Save();
        }

        public async Task<bool> Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
            return await Save();
        }
    }
}
