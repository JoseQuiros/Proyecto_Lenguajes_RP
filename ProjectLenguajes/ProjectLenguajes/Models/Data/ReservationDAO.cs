using Newtonsoft.Json;
using ProjectLenguajes.Models.Domain;
using System.Collections;
using System.Data.SqlClient;

namespace ProjectLenguajes.Models.Data
{
    public class ReservationDAO
    {

    //-------------------------------------------


    

        private readonly IConfiguration _configuration;
        string connectionString;

        public ReservationDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");  //esta es la llamada al string de conexión con la base de datos definido en el punto 3. 

        }

        public ReservationDAO()
        {

        }

        public int InsertReservation(Reservation reservation)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertReservation", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IDparking", reservation.IdParking);
                    command.Parameters.AddWithValue("@IDtime", reservation.IdTime);
                    command.Parameters.AddWithValue("@SlotNumber", reservation.IdParkingSlot);
                    command.Parameters.AddWithValue("@IDclient", reservation.IdClient);
                    command.Parameters.AddWithValue("@Date", reservation.Date);
                    command.Parameters.AddWithValue("@CantTime", reservation.CantTime);

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


    public String Get() //ya no es void, sino una lista
    {

        ArrayList reservations = new ArrayList();

        //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open(); //abrimos conexión
            SqlCommand command = new SqlCommand("GetAllReservation", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
            command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP

            //logica del get/select
            SqlDataReader sqlDataReader = command.ExecuteReader();
            //leemos todas las filas provenientes de BD
            while (sqlDataReader.Read())
            {
                reservations.Add(new
                {
                    IdReservation = Convert.ToInt32(sqlDataReader["IDreservation"]),
                    Parking = sqlDataReader["ParkingName"],
                    ParkingSlot = Convert.ToInt32(sqlDataReader["ParkingSlot"]),
                    Client = sqlDataReader["DNI"],
                    Vehicle = sqlDataReader["Vehicle"].ToString(),
                    Register = sqlDataReader["Register"].ToString(),
                    CantTime = Convert.ToInt32(sqlDataReader["CantTime"]),
                    Time = sqlDataReader["Time"],
                    TotalCost = sqlDataReader["CostTotal"],
                    InitDate = sqlDataReader["InitDate"],
                    InitHour = sqlDataReader["initHour"],
                    FinalDate = sqlDataReader["FinalDate"],
                });

            }

            connection.Close(); //cerramos conexión. 
        }

        var json = JsonConvert.SerializeObject(reservations);
        return json; //retornamos resultado al Controller.  

    }
        public String Get(int id) //ya no es void, sino una lista
        {

            ArrayList reservations = new ArrayList();

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("GetAllReservationByClient", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idClient", id);

                SqlDataReader sqlDataReader = command.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    reservations.Add(new
                    {
                        IdReservation = Convert.ToInt32(sqlDataReader["IDreservation"]),
                        Parking = sqlDataReader["ParkingName"],
                        ParkingSlot = Convert.ToInt32(sqlDataReader["ParkingSlot"]),
                        Client = sqlDataReader["DNI"],
                        Vehicle = sqlDataReader["Vehicle"].ToString(),
                        Register = sqlDataReader["Register"].ToString(),
                        CantTime = Convert.ToInt32(sqlDataReader["CantTime"]),
                        Time = sqlDataReader["Time"],
                        TotalCost = sqlDataReader["CostTotal"],
                        InitDate = sqlDataReader["InitDate"],
                        InitHour = sqlDataReader["initHour"],
                        FinalDate = sqlDataReader["FinalDate"],
                    });

                }

                connection.Close(); //cerramos conexión. 
            }

            var json = JsonConvert.SerializeObject(reservations);
            return json; //retornamos resultado al Controller.  

        }
    }
}
