using memory_words.Data.Interfaces;
using memory_words.Models;
using memory_words.Services.Interfaces;
using BCrypt.Net;


namespace memory_words.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository) 
        { 
        _loginRepository = loginRepository;
        }

        public bool Register(Login login)
        {
            if(_loginRepository.GetUserByEmail(login.Email) == null)
            {
                login.Password = BCrypt.Net.BCrypt.HashPassword(login.Password);
                _loginRepository.AddUser(login);
                return true;
            }
            return false;
        }

        public object Auth(string email, string password) 
        {
        var user = _loginRepository.GetUserByEmail(email);
            if(user != null)
            {
              var result = BCrypt.Net.BCrypt.Verify(password, user.Password);
                if (result)
                {
                    var userData = new { Email = user.Email, Id = user.LoginId };
                    return userData;
                }
                else return "Email or password incorrect";
            }           
            return "Email or password incorrect";        
        }

    }
}
