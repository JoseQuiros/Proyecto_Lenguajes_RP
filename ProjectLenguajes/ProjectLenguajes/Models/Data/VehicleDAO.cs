using ProjectLenguajes.Models.Domain;
using System.Data.SqlClient;

namespace ProjectLenguajes.Models.Data
{
    public class VehicleDAO
    {

        private readonly IConfiguration _configuration;
        string connectionString;

        public VehicleDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public int Insert(Vehicle vehicle)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertVehicle", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IDtype", vehicle.Idtype);
                    command.Parameters.AddWithValue("@Brand", vehicle.Brand);
                    command.Parameters.AddWithValue("@Model", vehicle.Model);
                    command.Parameters.AddWithValue("@Color", vehicle.Color);
                    command.Parameters.AddWithValue("@year", vehicle.Year);
                    command.Parameters.AddWithValue("@Register", vehicle.Register);
                    command.Parameters.AddWithValue("@Description", vehicle.Description);


                   

                    resultToReturn = Convert.ToInt32(command.ExecuteScalar());
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

        public List<Vehicle> Get()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAllVehicles", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    vehicles.Add(new Vehicle
                    {
                        //IdUser = Convert.ToInt32(sqlDataReader["IDuser"]),
                        Idvehicle = Convert.ToInt32(sqlDataReader["IDvehicle"]),
                        Idtype = Convert.ToInt32(sqlDataReader["IDtype"]),
                        //  Rol = new Rol(0, null, sqlDataReader["Name"].ToString()),
                        Brand = sqlDataReader["Brand"].ToString(),
                        Model = sqlDataReader["Model"].ToString(),
                        Color = sqlDataReader["Color"].ToString(),
                        Year = Convert.ToInt32(sqlDataReader["Year"]),
                        Register = sqlDataReader["Register"].ToString(),
                        Description = sqlDataReader["Description"].ToString()

                    });
                }
                connection.Close();

                return vehicles;

            }
        }

        public Vehicle Get(string email)
        {
            Vehicle vehicle = new Vehicle();
            return vehicle;
        }

        public int Update(Vehicle vehicle)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateVehicle", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDvehicle", vehicle.Idvehicle);
                    command.Parameters.AddWithValue("@IDtype",vehicle.Idtype);
                    command.Parameters.AddWithValue("@Brand", vehicle.Brand);
                    command.Parameters.AddWithValue("@Model",vehicle.Model );
                    command.Parameters.AddWithValue("@Color",vehicle.Color);
                    command.Parameters.AddWithValue("@Year",vehicle.Year);
                    command.Parameters.AddWithValue("@Register", vehicle.Register);
                    command.Parameters.AddWithValue("@Description", vehicle.Description);


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


        public Vehicle Get(int id)
        {
            Vehicle vehicle = new Vehicle();
            Exception? exception = new Exception();
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("GetVehicle", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDvehicle", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        vehicle.Idvehicle = Convert.ToInt32(sqlDataReader["IDvehicle"]);
                        vehicle.Idtype = Convert.ToInt32(sqlDataReader["IDtype"]);
                        //  Rol = new Rol(0, null, sqlDataReader["Name"].ToString()),
                        vehicle.Brand = sqlDataReader["Brand"].ToString();
                        vehicle.Model = sqlDataReader["Model"].ToString();
                        vehicle.Color = sqlDataReader["Color"].ToString();
                        vehicle.Year = Convert.ToInt32(sqlDataReader["Year"]);
                        vehicle.Register = sqlDataReader["Register"].ToString();
                        vehicle.Description = sqlDataReader["Description"].ToString();
                    }

                    connection.Close();


                    return vehicle;
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

