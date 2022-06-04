using ProjectLenguajes.Models.Domain;
using System.Data.SqlClient;

namespace ProjectLenguajes.Models.Data
{
    public class FeeDAO
    {

        private readonly IConfiguration _configuration;
        string connectionString;

        public FeeDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");  //esta es la llamada al string de conexión con la base de datos definido en el punto 3. 

        }

        public FeeDAO()
        {

        }

        public List<Fee> Get() //ya no es void, sino una lista
        {

            List<Fee> fees = new List<Fee>();

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("GetAllFees", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP

                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                //leemos todas las filas provenientes de BD
                while (sqlDataReader.Read())
                {
                    fees.Add(new Fee
                    {
                        IdFee = Convert.ToInt32(sqlDataReader["IDFee"]),
                        IdtypeVehicle = Convert.ToInt32(sqlDataReader["IDtypeVehicle"]),
                        IdTime = Convert.ToInt32(sqlDataReader["IDtime"]),
                        Price = (float)Convert.ToDouble(sqlDataReader["Price"])
                    });
                }
                connection.Close(); //cerramos conexión. 
            }
            return fees; //retornamos resultado al Controller.
        }

        public int InsertFee(Fee fee)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertFee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IDtypeVehicle", fee.IdtypeVehicle);
                    command.Parameters.AddWithValue("@IDtime", fee.IdTime);
                    command.Parameters.AddWithValue("@Price", fee.Price);

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

        public Fee Get(int id)
        {
            Fee fee = new Fee();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetFee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDfee", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        fee.IdFee = Convert.ToInt32(sqlDataReader["IDfee"]);
                        fee.IdtypeVehicle = Convert.ToInt32(sqlDataReader["IDtypeVehicle"]);
                        fee.IdTime = Convert.ToInt32(sqlDataReader["IDTime"]);
                        fee.Price = (float)Convert.ToDouble(sqlDataReader["Price"]);
                    }
                    connection.Close();

                    return fee;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }

        public int UpdateFee(Fee fee)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateFee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDfee", fee.IdFee);

                    command.Parameters.AddWithValue("@IDtypeVehicle", fee.IdtypeVehicle);
                    command.Parameters.AddWithValue("@IDtime", fee.IdTime);
                    command.Parameters.AddWithValue("@Price", fee.Price);

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
                    SqlCommand command = new SqlCommand("DeleteFee", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDfee", id);

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
