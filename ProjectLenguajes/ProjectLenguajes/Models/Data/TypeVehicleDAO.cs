
using System.Collections;
using System.Data.SqlClient;
using Newtonsoft.Json;
using ProjectLenguajes.Models.Domain;

namespace ProjectLenguajes.Models.Data
{
    public class TypeVehicleDAO
    {

        private readonly IConfiguration _configuration;
        string connectionString;

        public TypeVehicleDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");  //esta es la llamada al string de conexión con la base de datos definido en el punto 3. 

        }

        public TypeVehicleDAO()
        {

        }

        public String Get() //ya no es void, sino una lista
        {

           ArrayList types = new ArrayList();

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("GetTypes", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP

                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                //leemos todas las filas provenientes de BD
                while (sqlDataReader.Read())
                {
                    types.Add(new 
                    {
                        IdType = Convert.ToInt32(sqlDataReader["IDtype"]),
                        Name = sqlDataReader["Name"].ToString()

                    });

                }

                connection.Close(); //cerramos conexión. 
            }
            var json = JsonConvert.SerializeObject(types);
            return json; //retornamos resultado al Controller.  

        }

    }
}
