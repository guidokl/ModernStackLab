using ModernStackLab.Data;
using ModernStackLab.Models;
using Microsoft.EntityFrameworkCore;

namespace ModernStackLab.Services
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        
        public ContactService(AppDbContext context)
        {
            _context = context; 
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetByIdAsync(int id)
        {
            return await _context.Contacts.FindAsync();
        }

        public async Task CreateAsync(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
