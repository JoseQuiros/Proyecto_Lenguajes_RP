
using System.Collections;
using System.Data.SqlClient;
using Newtonsoft.Json;
using ProjectLenguajes.Models.Domain;

namespace ProjectLenguajes.Models.Data
{
    public class ParkingSlotDAO
    {

        private readonly IConfiguration _configuration;
        string connectionString;

        public ParkingSlotDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");  //esta es la llamada al string de conexión con la base de datos definido en el punto 3. 

        }

        public ParkingSlotDAO()
        {

        }

        public String Get() //ya no es void, sino una lista
        {

            ArrayList parkingSlots = new ArrayList();

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("GetAllParkingSlots", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP

                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                //leemos todas las filas provenientes de BD
                while (sqlDataReader.Read())
                {
                    parkingSlots.Add(new 
                    {
                        IdParkingSlot = Convert.ToInt32(sqlDataReader["IDparkingSlot"]),
                        IdParking = Convert.ToInt32(sqlDataReader["IDparking"]),
                        IdTypeVehicle = Convert.ToInt32(sqlDataReader["IDtypeVehicle"]),
                        Number = Convert.ToInt32(sqlDataReader["Number"]),
                        PreferentialSlot = sqlDataReader["PreferentialSlot"].ToString(),
                        State = sqlDataReader["State"].ToString()

                    });

                }

                connection.Close(); //cerramos conexión. 
            }

            var json = JsonConvert.SerializeObject(parkingSlots);
            return json; //retornamos resultado al Controller.  

        }


        


        public List<ParkingSlot> GetSlotsByParking(int id) //ya no es void, sino una lista
        {

            List<ParkingSlot> parkingSlots = new List<ParkingSlot>();


          

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("GetSlotsByParking", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idParking", id);
                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                //leemos todas las filas provenientes de BD
                while (sqlDataReader.Read())
                {
                    parkingSlots.Add(new ParkingSlot
                    {
                        IdParkingSlot = Convert.ToInt32(sqlDataReader["IDparkingSlot"]),
                        IdParking = Convert.ToInt32(sqlDataReader["IDparking"]),
                        IdTypeVehicle = Convert.ToInt32(sqlDataReader["IDtypeVehicle"]),
                        Number = Convert.ToInt32(sqlDataReader["Number"]),
                        PreferentialSlot = sqlDataReader["PreferentialSlot"].ToString(),
                        State = sqlDataReader["State"].ToString()

                    });

                }

                connection.Close(); //cerramos conexión. 
            }
            return parkingSlots; //retornamos resultado al Controller.  

        }




        public int InsertParkingSlot(ParkingSlot parkingSlot)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertPakingSlot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IDparking", parkingSlot.IdParking);
                 
                    command.Parameters.AddWithValue("@IDtypeVehicle", parkingSlot.IdTypeVehicle);
                    command.Parameters.AddWithValue("@Number", parkingSlot.Number);
                    command.Parameters.AddWithValue("@PreferentialSlot", parkingSlot.PreferentialSlot);

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

        public ParkingSlot Get(int id)
        {
            ParkingSlot parkingSlot = new ParkingSlot();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetParkingSlot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDparkingSlot", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        parkingSlot.IdParkingSlot = Convert.ToInt32(sqlDataReader["IDparkingSlot"]);
                        parkingSlot.IdParking = Convert.ToInt32(sqlDataReader["IDparking"]);
                        parkingSlot.IdTypeVehicle = Convert.ToInt32(sqlDataReader["IDtypeVehicle"]);
                        parkingSlot.Number = Convert.ToInt32(sqlDataReader["Number"]);
                        parkingSlot.PreferentialSlot = sqlDataReader["PreferentialSlot"].ToString();
                        parkingSlot.State = sqlDataReader["State"].ToString();
                    }

                    connection.Close();


                    return parkingSlot;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }

        public ParkingSlot GetSlotInfo(int id, string timeName)
        {
            ParkingSlot parkingSlot = new ParkingSlot();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetParkingSlot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDparkingSlot", id);
                    command.Parameters.AddWithValue("@@nameTime", timeName);
                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        parkingSlot.IdParkingSlot = Convert.ToInt32(sqlDataReader["IDparkingSlot"]);
                        parkingSlot.IdParking = Convert.ToInt32(sqlDataReader["IDparking"]);
                        parkingSlot.IdTypeVehicle = Convert.ToInt32(sqlDataReader["IDtypeVehicle"]);
                        parkingSlot.Number = Convert.ToInt32(sqlDataReader["Number"]);
                        parkingSlot.PreferentialSlot = sqlDataReader["PreferentialSlot"].ToString();
                        parkingSlot.State = sqlDataReader["State"].ToString();
                    }

                    connection.Close();


                    return parkingSlot;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }




        public int UpdateParkingSlot(ParkingSlot parkingSlot)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateParkingSlot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDparkingSlot", parkingSlot.IdParkingSlot);
                    command.Parameters.AddWithValue("@IDtypeVehicle", parkingSlot.IdTypeVehicle);
                    command.Parameters.AddWithValue("@PreferentialSlot", parkingSlot.PreferentialSlot);

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

        public int Delete(int id)
        {
            int resultToReturn = 0;
            Fee fee = new Fee();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteParkingSlot", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDparkingSlot", id);

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
