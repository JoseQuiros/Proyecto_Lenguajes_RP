using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectLenguajes.Models.Domain;
using System.Collections;
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

        public String Get()
        {
            ArrayList clients = new ArrayList();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllClients", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {

                    clients.Add(new 
                    {
                        IdClient = Convert.ToInt32(sqlDataReader["IDclient"]),



                        Name = sqlDataReader["Name"].ToString(),
                        Dni = sqlDataReader["DNI"].ToString(),
                        Age = Convert.ToInt32(sqlDataReader["Age"]),
                        Telephone = sqlDataReader["Telephone"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Register = sqlDataReader["Register"].ToString()

                    });

                }

                connection.Close();

                var json = JsonConvert.SerializeObject(clients);
                return json;

            }
        }

        
        public int UpdateClient(Client client)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateClient", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDClient", client.IdClient);
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
        public Client Get(int id)
        {
            Client client = new Client();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("GetClient", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDclient", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        client.IdClient = Convert.ToInt32(sqlDataReader["IDclient"]);
                        client.IdVehicle = Convert.ToInt32(sqlDataReader["IDvehicle"]);
                        //  Rol = new Rol(0, null, sqlDataReader["Name"].ToString()),
                        client.Name = sqlDataReader["Name"].ToString();
                        client.Dni = sqlDataReader["DNI"].ToString();
                        client.Age = Convert.ToInt32(sqlDataReader["Age"]);
                        client.Telephone = sqlDataReader["Telephone"].ToString();
                        client.Email = sqlDataReader["Email"].ToString();
                        client.Password = sqlDataReader["Password"].ToString();

                    }

                    connection.Close();


                    return client;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }



        public string GetJsonClient(int id)
        {
            ArrayList objs = new ArrayList();
            Client client = new Client();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("GetClient", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDclient", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {

                        objs.Add(new
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
                }

                //clean up datareader

                var json = JsonConvert.SerializeObject(objs);
        


              return json;

                 }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }
public int Delete(int id)
        {
            int resultToReturn = 0;
            Client client = new Client();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteClient", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDclient", id);

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