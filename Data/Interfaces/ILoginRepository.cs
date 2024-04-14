using memory_words.Models;

namespace memory_words.Data.Interfaces
{
    public interface ILoginRepository
    {
        Login GetUserByEmail(string email);
        void AddUser(Login login);
    }
}
