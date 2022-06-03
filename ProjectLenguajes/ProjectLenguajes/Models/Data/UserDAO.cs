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
                    SqlCommand command = new SqlCommand("InsertUser", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IDrol", user.IdRol);
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
                SqlCommand command = new SqlCommand("GetAllUser", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    users.Add(new User
                    {
                        //IdUser = Convert.ToInt32(sqlDataReader["IDuser"]),
                        IdUser = Convert.ToInt32(sqlDataReader["IDuser"]),
                        IdRol = Convert.ToInt32(sqlDataReader["IDrol"]),
                      //  Rol = new Rol(0, null, sqlDataReader["Name"].ToString()),
                        Name = sqlDataReader["Name"].ToString(),
                        Dni= sqlDataReader["DNI"].ToString(),
                        Age = Convert.ToInt32(sqlDataReader["Age"]),
                        Telephone = sqlDataReader["Telephone"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Password = sqlDataReader["Password"].ToString()
                      

                    });

                }

                connection.Close();

                return users;

            }
        }


        public User Get(string email)
        {
            User user = new User();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("LogIn", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", email);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        //IdUser = Convert.ToInt32(sqlDataReader["IDuser"]),
                        user.IdUser = Convert.ToInt32(sqlDataReader["IDuser"]);
                        user.IdRol = Convert.ToInt32(sqlDataReader["IDrol"]);
                        //  Rol = new Rol(0, null, sqlDataReader["Name"].ToString()),
                        user.Name = sqlDataReader["Name"].ToString();
                        user.Dni = sqlDataReader["DNI"].ToString();
                        user.Age = Convert.ToInt32(sqlDataReader["Age"]);
                        user.Telephone = sqlDataReader["Telephone"].ToString();
                        user.Email = sqlDataReader["Email"].ToString();
                        user.Password = sqlDataReader["Password"].ToString();
                    }
                    connection.Close();
                    return user;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }





        public User Get(int id)
        {
            User user = new User();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("GetUser", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDuser", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        user.IdUser = Convert.ToInt32(sqlDataReader["IDuser"]);
                        user.IdRol = Convert.ToInt32(sqlDataReader["IDrol"]);
                        // client.IdVehicle = Convert.ToInt32(sqlDataReader["IDvehicle"]);
                        //  Rol = new Rol(0, null, sqlDataReader["Name"].ToString()),
                        user.Name = sqlDataReader["Name"].ToString();
                        user.Dni = sqlDataReader["DNI"].ToString();
                        user.Age = Convert.ToInt32(sqlDataReader["Age"]);
                        user.Telephone = sqlDataReader["Telephone"].ToString();
                        user.Email = sqlDataReader["Email"].ToString();
                        user.Password = sqlDataReader["Password"].ToString();

                    }

                    connection.Close();


                    return user;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }

        public int Update(User user)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateUser", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDUser", user.IdUser);
                    command.Parameters.AddWithValue("@IDRol", user.IdRol);
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



        public User Delete(int id)
        {
            User user = new User();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteUser", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDuser", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        user.IdUser = Convert.ToInt32(sqlDataReader["IDuser"]);
                        user.IdRol = Convert.ToInt32(sqlDataReader["IDrol"]);
                        // client.IdVehicle = Convert.ToInt32(sqlDataReader["IDvehicle"]);
                        //  Rol = new Rol(0, null, sqlDataReader["Name"].ToString()),
                        user.Name = sqlDataReader["Name"].ToString();
                        user.Dni = sqlDataReader["DNI"].ToString();
                        user.Age = Convert.ToInt32(sqlDataReader["Age"]);
                        user.Telephone = sqlDataReader["Telephone"].ToString();
                        user.Email = sqlDataReader["Email"].ToString();
                        user.Password = sqlDataReader["Password"].ToString();

                    }

                    connection.Close();


                    return user;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }


    }


}

