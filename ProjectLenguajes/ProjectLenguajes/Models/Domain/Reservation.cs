namespace ProjectLenguajes.Models.Domain
{
    public class Reservation
    {

        private int idReservation;
        private int idParking;
        private int idParkingSlot;
        private int idClient;
        private int cantTime;
        private int idTime;
        private int idVehicle;
        private float totalCost;
        private string date;

        public Reservation()
        {
        }

        public Reservation(int idReservation, int idParking, int idParkingSlot, int idClient, int cantTime, int idTime, int idVehicle, float totalCost, string date)
        {
            this.idReservation = idReservation;
            this.idParking = idParking;
            this.idParkingSlot = idParkingSlot;
            this.idClient = idClient;
            this.cantTime = cantTime;
            this.idTime = idTime;
            this.idVehicle = idVehicle;
            this.totalCost = totalCost;
            this.date = date;
    
        }

        public int IdReservation { get => idReservation; set => idReservation = value; }
        public int IdParking { get => idParking; set => idParking = value; }
        public int IdParkingSlot { get => idParkingSlot; set => idParkingSlot = value; }
        public int IdClient { get => idClient; set => idClient = value; }
        public int CantTime { get => cantTime; set => cantTime = value; }
        public int IdTime { get => idTime; set => idTime = value; }
        public int IdVehicle { get => idVehicle; set => idVehicle = value; }
        public float TotalCost { get => totalCost; set => totalCost = value; }
        public string Date { get => date; set => date = value; }
    
    }
}

