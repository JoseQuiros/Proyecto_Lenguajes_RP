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

        public int Insert(User user)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertStudent", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IdRol", user.IdRol);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@DNI", user.Dni);
                    command.Parameters.AddWithValue("@Age", user.Age);
                    command.Parameters.AddWithValue("@Telephone", user.Telephone);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);

                    resultToReturn = command.ExecuteNonQuery();
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }


            return resultToReturn;

        }

        public List<User> Get()
        {

            List<User> users = new List<User>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("GetAllStudents", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    users.Add(new User
                    {
                        IdUser = Convert.ToInt32(sqlDataReader["Iduser"]),
                        IdRol = Convert.ToInt32(sqlDataReader["Idrol"]),
                        Name= sqlDataReader["Name"].ToString(),
                        Dni= sqlDataReader["DNI"].ToString(),
                        Age = Convert.ToInt32(sqlDataReader["Age"]),
                        Telephone = sqlDataReader["Telephone"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Password = sqlDataReader["Password"].ToString()
                       // Major = new Major(0, null, sqlDataReader["MajorName"].ToString())

                    });

                }

                connection.Close();

                return users;

            }
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

