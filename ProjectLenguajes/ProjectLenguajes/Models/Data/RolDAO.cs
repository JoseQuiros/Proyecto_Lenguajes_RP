using Newtonsoft.Json;
using ProjectLenguajes.Models.Domain;
using System.Collections;
using System.Data.SqlClient;

namespace ProjectLenguajes.Models.Data
{
    public class RolDAO
    {

        private readonly IConfiguration _configuration;
        string connectionString;

        public RolDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");  //esta es la llamada al string de conexión con la base de datos definido en el punto 3. 

        }


        public String GetRols() //ya no es void, sino una lista
        {

            ArrayList rols = new ArrayList();

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("GetAllRoles", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP

                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                //leemos todas las filas provenientes de BD
                while (sqlDataReader.Read())
                {
                    rols.Add(new
                    {
                        IdRol = Convert.ToInt32(sqlDataReader["IDrol"]),
                        Name = sqlDataReader["Name"],
                        Authority = sqlDataReader["Authority"],
                     

                    });

                }

                connection.Close(); //cerramos conexión. 
            }

            var json = JsonConvert.SerializeObject(rols);
            return json; //retornamos resultado al Controller.  

        }


        public Rol GetRols(int id) //ya no es void, sino una lista
        {
            Rol rol = new Rol();
            var result = "";

            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("GetRol", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP
                command.Parameters.AddWithValue("@IDrol", id);
                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                //leemos todas las filas provenientes de BD
                if (sqlDataReader.Read())
                {

                    rol.IdRol = Convert.ToInt32(sqlDataReader["IDrol"]);
                    rol.Name = sqlDataReader["Name"].ToString();
                    rol.Authority = Convert.ToInt32(sqlDataReader["Authority"].ToString());


                    return rol;
                }

                connection.Close(); //cerramos conexión. 
            }



            return rol;

        }


        public int Delete(int id)
        {
            int resultToReturn = 0;
            Rol rol = new Rol();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("DeleteRol", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDrol", id);

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


     




        public int UpdateRol(Rol rol)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UpdateRol", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDrol", rol.IdRol);

                    command.Parameters.AddWithValue("@Authority", rol.Authority);

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

        public Rol Get(int id)
        {
            Rol rol = new Rol();
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetRol", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDrol", id);

                    SqlDataReader sqlDataReader = command.ExecuteReader();


                    if (sqlDataReader.Read())
                    {
                        rol.IdRol = Convert.ToInt32(sqlDataReader["IDrol"]);

                        rol.Name = sqlDataReader["Name"].ToString();
                        rol.Authority = Convert.ToInt32(sqlDataReader["Authority"]);

                    }

                    connection.Close();


                    return rol;
                }
            }
            catch (Exception ex)
            {
                exception = ex;
                throw exception;
            }
        }

        public int Insert(Rol rol)
        {
            int resultToReturn = 0;//it will save 1 or 0 depending on the result of insertion
            Exception? exception = new Exception();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {


                    connection.Open();
                    SqlCommand command = new SqlCommand("InsertRol", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Name", rol.Name);
                    command.Parameters.AddWithValue("@Authority", rol.Authority);

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
