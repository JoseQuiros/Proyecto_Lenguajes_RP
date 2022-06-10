using Newtonsoft.Json;
using ProjectLenguajes.Models.Domain;
using System.Collections;
using System.Data.SqlClient;

namespace ProjectLenguajes.Models.Data
{
    public class BillDAO
    {

        private readonly IConfiguration _configuration;
        string connectionString;

        public BillDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");  //esta es la llamada al string de conexión con la base de datos definido en el punto 3. 

        }

        public int InsertBill(Bill bill)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertBill", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IDreservation", bill.IdBill);
                    command.Parameters.AddWithValue("@Client", bill.Client);
                    command.Parameters.AddWithValue("@Vehicle", bill.Vehicle);
                    command.Parameters.AddWithValue("@Parking", bill.Parking);
                    command.Parameters.AddWithValue("@ParkingSlot", bill.ParkingSlot);
                    command.Parameters.AddWithValue("@TotalCost", bill.TotalCost);
                    command.Parameters.AddWithValue("@Facturator", bill.Facturator);

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

            ArrayList bills = new ArrayList();

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("GetBills", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP

                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                //leemos todas las filas provenientes de BD
                while (sqlDataReader.Read())
                {
                    bills.Add(new
                    {
                        IdBill = Convert.ToInt32(sqlDataReader["IDbill"]),
                        Client = sqlDataReader["Client"].ToString(),
                        Vehicle = sqlDataReader["Vehicle"].ToString(),
                        DateRem = sqlDataReader["DateRem"],
                        Parking = sqlDataReader["Parking"],
                        ParkingSlot = Convert.ToInt32(sqlDataReader["ParkingSlot"]),
                        TotalCost = sqlDataReader["TotalCost"],
                        Facturator = sqlDataReader["Facturator"],
                    });

                }

                connection.Close(); //cerramos conexión. 
            }

            var json = JsonConvert.SerializeObject(bills);
            return json; //retornamos resultado al Controller.  

        }
    }
}
