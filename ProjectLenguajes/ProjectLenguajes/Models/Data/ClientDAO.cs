using ProjectLenguajes.Models.Domain;
using System.Data.SqlClient;

namespace ProjectLenguajes.Models.Data
{
    public class ClientDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;
        /// private object client = new Client();

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

                    //command.Parameters.AddWithValue("@IDvehicle", client.IdVehicle);
                    //command.Parameters.AddWithValue("@Name", client.User.Name);
                    //command.Parameters.AddWithValue("@DNI", client.User.Dni);
                    //command.Parameters.AddWithValue("@Age", client.User.Age);
                    //command.Parameters.AddWithValue("@Telephone", client.User.Telephone);
                    //command.Parameters.AddWithValue("@Email", client.User.Email);
                    //command.Parameters.AddWithValue("@Password", client.User.Password);

                    command.Parameters.AddWithValue("@IDvehicle", client.IdVehicle);
                    command.Parameters.AddWithValue("@Name", client.Name);
                    command.Parameters.AddWithValue("@DNI", client.Dni);
                    command.Parameters.AddWithValue("@Age", client.Age);
                    command.Parameters.AddWithValue("@Telephone", client.Telephone);
                    command.Parameters.AddWithValue("@Email", client.Email);
                    command.Parameters.AddWithValue("@Password", client.Password);

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

        public List<Client> Get()
        {
            List<Client> clients = new List<Client>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllClients", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    clients.Add(new Client
                    {
                        IdClient = Convert.ToInt32(sqlDataReader["IDclient"]),
                        IdVehicle = Convert.ToInt32(sqlDataReader["IDvehicle"]),
                        State = sqlDataReader["State"].ToString(),
                        //aqui los de user
                        Name = sqlDataReader["Name"].ToString(),
                        Dni = sqlDataReader["DNI"].ToString(),
                        Age = Convert.ToInt32(sqlDataReader["Age"]),
                        Telephone = sqlDataReader["Telephone"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Password = sqlDataReader["Password"].ToString(),
                        IdRol = Convert.ToInt32(sqlDataReader["IDrol"]),
                    });

                }

                connection.Close();

                return clients;

            }
        }
    }
}