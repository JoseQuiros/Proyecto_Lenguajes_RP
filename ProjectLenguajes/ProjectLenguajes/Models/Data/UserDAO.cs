using ProjectLenguajes.Models.Domain;
using System.Data.SqlClient;

namespace ProjectLenguajes.Models.Data
{
    public class UserDAO
    {

        private readonly IConfiguration _configuration;
        string connectionString;

        public UserDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public int Insert(User User)
        {

            return 1;
        }

      
        public User Get(string email)
        {
            User user = new User();
        return user;    
        }


        public int Update(User User)
        {
         

            return 1;

        }
    }


}

