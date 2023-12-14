using TestApp1.Models;

namespace TestApp1.Services
{
    public interface IRegisterService
    {
        List<UserModel> FetchAll();
        public void Adduser(UserModel user);
    }
}
