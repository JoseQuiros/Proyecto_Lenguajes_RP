using ProjectLenguajes.Models.Domain;
using System.Data.SqlClient;

namespace ProjectLenguajes.Models.Data
{
    public class ClientDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public ClientDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public int Insert(Client client)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertClient", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IDvehicle", client.IdVehicle);
                    command.Parameters.AddWithValue("@Name", client.User.Name);
                    command.Parameters.AddWithValue("@DNI", client.User.Dni);
                    command.Parameters.AddWithValue("@Age", client.User.Age);
                    command.Parameters.AddWithValue("@Telephone", client.User.Telephone);
                    command.Parameters.AddWithValue("@Email", client.User.Email);
                    command.Parameters.AddWithValue("@Password", client.User.Password);

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
    }
}

    //    public List<User> Get()
    //    {

    //        List<User> users = new List<User>();
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {

    //            connection.Open();
    //            SqlCommand command = new SqlCommand("GetAllUser", connection);
    //            command.CommandType = System.Data.CommandType.StoredProcedure;

    //            SqlDataReader sqlDataReader = command.ExecuteReader();
    //            while (sqlDataReader.Read())
    //            {

    //                users.Add(new User
    //                {
    //                    //IdUser = Convert.ToInt32(sqlDataReader["IDuser"]),
    //                    IdUser = Convert.ToInt32(sqlDataReader["IDuser"]),
    //                    IdRol = Convert.ToInt32(sqlDataReader["IDrol"]),
    //                    //  Rol = new Rol(0, null, sqlDataReader["Name"].ToString()),
    //                    Name = sqlDataReader["Name"].ToString(),
    //                    Dni = sqlDataReader["DNI"].ToString(),
    //                    Age = Convert.ToInt32(sqlDataReader["Age"]),
    //                    Telephone = sqlDataReader["Telephone"].ToString(),
    //                    Email = sqlDataReader["Email"].ToString(),
    //                    Password = sqlDataReader["Password"].ToString()


    //                });

    //            }

    //            connection.Close();

    //            return users;

    //        }
    //    }
    //}
//}
