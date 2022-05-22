namespace ProjectLenguajes.Models.Domain
{
    public class Client : User
    {
        private int idClient;
        private int idVehicle;
        private String state;
        private int age;
        private User user;

        public Client()
        {

        }

        public Client(int idClient, int idVehicle, string state, int age, User user)
        {
            this.idClient = idClient;
            this.idVehicle = idVehicle;
            this.state = state;
            this.age = age;
            this.user = user;
        }

       



        public int IdClient { get => IdClient; set => IdClient = value; }
        public int IdVehicle{ get => idVehicle; set => idVehicle = value; }
        public string State { get => state; set => state = value; }
        public int Age { get => age; set => age = value; }
        public User User { get => user; set => user = value; }


    }
   

}
