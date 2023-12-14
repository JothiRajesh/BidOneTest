using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using TestApp1.Models;

namespace TestApp1.Services
{
    public class RegisterService: IRegisterService
    {
        private readonly IConfiguration _configuration;
        private string _filePath = "";
        public RegisterService(IConfiguration configuration)
        {
            _configuration = configuration;
            _filePath = _configuration.GetValue<string>("Connection:FilePath").ToString();
        }

        public List<UserModel> FetchAll()
        {
            string jsonData;

            
            using(var reader =  new StreamReader(_filePath))
            {
                jsonData = reader.ReadToEnd();
            }

            var users = JsonConvert.DeserializeObject<List<UserModel>>(jsonData);

            if(users != null)
            {
                return users;
            }
            return new List<UserModel>();
        }

        public void Adduser(UserModel user)
        {
            string jsonData;
            using (var reader = new StreamReader(_filePath))
            {
                jsonData = reader.ReadToEnd();
            }

            var users = JsonConvert.DeserializeObject<List<UserModel>>(jsonData);

            int maxId = 0;
            if (users != null && users.Count > 0)
            {
                maxId = users.MaxBy(x => x.Id).Id;
            }
            else
            {
                users = new List<UserModel>();
            }
            user.Id = maxId+1;

            users.Add(user);

            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(_filePath, json);
            
        }
    }
}
