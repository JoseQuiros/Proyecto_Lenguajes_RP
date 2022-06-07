using ProjectLenguajes.Models.Domain;
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

    }
}
