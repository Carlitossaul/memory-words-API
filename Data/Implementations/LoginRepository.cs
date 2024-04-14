using memory_words.Data.Interfaces;
using memory_words.Models;

namespace memory_words.Data.Implementations
{

    public class LoginRepository : ILoginRepository
    {
        private readonly MemoryContext _memoryContext;
        public LoginRepository(MemoryContext memoryContext)
        {
        
            _memoryContext = memoryContext;
        }
        public Login GetUserByEmail(string email) {

            return _memoryContext.Logins.FirstOrDefault(l => l.Email == email);
                
        }

        public void AddUser(Login login)
        {
            _memoryContext.Logins.Add(login);
            _memoryContext.SaveChanges();
        }

    }
}
