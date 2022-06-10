namespace ProjectLenguajes.Models.Domain
{
    public class Bill
    {

        private int idBill;
        private string client;
        private string vehicle;
        private DateTime dateRem;
        private string parking;
        private int parkingSlot;
        private float totalCost;
        private string facturator;

        public Bill()
        {
        }

        public Bill(int idBill, string client, string vehicle, DateTime dateRem, string parking, int parkingSlot, float totalCost, string facturator)
        {
            this.idBill = idBill;
            this.client = client;
            this.vehicle = vehicle;
            this.dateRem = dateRem;
            this.parking = parking;
            this.parkingSlot = parkingSlot;
            this.totalCost = totalCost;
            this.facturator = facturator;
        }

        public int IdBill { get => idBill; set => idBill = value; }
        public string Client { get => client; set => client = value; }
        public string Vehicle { get => vehicle; set => vehicle = value; }
        public DateTime DateRem { get => dateRem; set => dateRem = value; }
        public string Parking { get => parking; set => parking = value; }
        public int ParkingSlot { get => parkingSlot; set => parkingSlot = value; }
        public float TotalCost { get => totalCost; set => totalCost = value; }        
        public string Facturator { get => facturator; set => facturator = value; }
    }
}
