namespace ProjectLenguajes.Models.Domain
{
    public class Parking
    {
        private int idParking;
        private string parkingName;

        public Parking()
        {
        }

        public Parking(int idParking, string parkingName)
        {
            this.idParking = idParking;
            this.parkingName = parkingName;
        }

        public int IdParking { get => idParking; set => idParking = value; }
        public string ParkingName { get => parkingName; set => parkingName = value; }
    }
}
