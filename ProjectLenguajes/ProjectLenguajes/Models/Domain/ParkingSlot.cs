namespace ProjectLenguajes.Models.Domain
{
    public class ParkingSlot
    {

        private int idParkingSlot;
        private int idParking;
        private int idTypeVehicle;
        private int number;
        private string preferentialSlot;
        private string state;

        public ParkingSlot()
        {
        }

        public ParkingSlot(int idParkingSlot, int idParking, int idTypeVehicle, int number, string preferentialSlot, string state)
        {
            this.idParkingSlot = idParkingSlot;
            this.idParking = idParking;
            this.idTypeVehicle = idTypeVehicle;
            this.number = number;
            this.preferentialSlot = preferentialSlot;
            this.state = state;
        }

        public ParkingSlot(int idParkingSlot, int idParking, int idTypeVehicle, string preferentialSlot)
        {
            this.idParkingSlot = idParkingSlot;
            this.idParking = idParking;
            this.idTypeVehicle = idTypeVehicle;
            this.preferentialSlot = preferentialSlot;
        }

        public ParkingSlot(int idParkingSlot, int idParking, int idTypeVehicle)
        {
            this.idParkingSlot = idParkingSlot;
            this.idParking = idParking;
            this.idTypeVehicle = idTypeVehicle;
        }
        public int IdParkingSlot { get => idParkingSlot; set => idParkingSlot  = value; }
        public int IdParking { get => idParking; set => idParking = value; }
        public int IdTypeVehicle { get => idTypeVehicle; set => idTypeVehicle = value; }
        public int Number { get => number; set => number = value; }
        public string PreferentialSlot { get => preferentialSlot; set => preferentialSlot = value; }
        public string State { get => state; set => state = value; }
    }
}
