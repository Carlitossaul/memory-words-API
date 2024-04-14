using memory_words.Models;
using System.Threading.Tasks;

namespace memory_words.Services.Interfaces
{
    public interface ILoginService
    {
        bool Register(Login login);
        object Auth(string email, string password);
    }
}
