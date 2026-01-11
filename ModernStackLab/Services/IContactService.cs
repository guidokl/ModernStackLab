using ModernStackLab.Models;

namespace ModernStackLab.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact?> GetByIdAsync(int id);
        Task CreateAsync(Contact contact); // async version of void
        Task DeleteAsync(int id);
    }
}
