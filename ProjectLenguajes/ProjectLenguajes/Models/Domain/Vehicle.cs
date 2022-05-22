namespace ProjectLenguajes.Models.Domain
{
    public class Vehicle
    {
        private int idVehicle;
        private int idType;
        private string brand;
        private string model;
        private string color;
        private int year;
        private string register;
        private string description;


        public Vehicle()
        {

        }

        public Vehicle(int idVehicle, int idType, string brand, string model, string color, int year, string register, string description)
        {
            this.idVehicle = idVehicle;
            this.idType = idType;
            this.brand = brand;
            this.model = model;
            this.color = color;
            this.year = year;
            this.register = register;
            this.description = description;
        }

        public int Idvehicle { get => idVehicle; set => idVehicle = value; }
        public int Idtype { get => idType; set => idType = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string Color { get => color; set => color = value; }
        public int Year { get => year; set => year = value; }
        public string Register { get => register; set => register = value; }
        public string Description { get => description; set => description = value; }


    }
 
    

}
