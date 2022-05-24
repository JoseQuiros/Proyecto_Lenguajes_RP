namespace ProjectLenguajes.Models.Domain
{
    //public class Client : User
    public class Client
    {
        private int idClient;
        private int idVehicle;
        private String state;
        //private User user;
        //user
        private int idRol;
        private string name;
        private string dni;
        private int age;
        private string telephone;
        private string email;
        private string password;


        public Client()
        {

        }

        public Client(int idClient, int idVehicle, string state, int idRol, string name, string dni, int age, string telephone, string email, string password)
        {
            this.idClient = idClient;
            this.idVehicle = idVehicle;
            this.state = state;
            //user
            this.idRol = idRol;
            this.name = name;
            this.dni = dni;
            this.age = age;
            this.telephone = telephone;
            this.email = email;
            this.password = password;
        }





        public int IdClient { get => idClient; set => idClient = value; }
        public int IdVehicle { get => idVehicle; set => idVehicle = value; }
        public string State { get => state; set => state = value; }
        //public int Age { get => age; set => age = value; }
        //public User User { get => user; set => user = value; }
        //user
        public int IdRol { get => idRol; set => idRol = value; }
        public string Name { get => name; set => name = value; }
        public string Dni { get => dni; set => dni = value; }
        public int Age { get => age; set => age = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }


    }


}