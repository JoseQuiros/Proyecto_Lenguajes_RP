namespace ProjectLenguajes.Models.Domain
{
    public class Client : User
    {
        private int idClient;
        private int idVehicle;
        private String state;
        private int age;


        public Client()
        {

        }

        public Client(int idClient, int idVehicle, string state, int age)
        {
            this.idClient = idClient;
            this.idVehicle = idVehicle;
            this.state = state;
            this.age = age;
        }

        public Client(int idUser, int idRol, string name, string dni, int age, string telephone, string email, string password) : base(idUser, idRol, name, dni, age, telephone, email, password)
        {
        }
    }
   

}
