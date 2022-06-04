namespace ProjectLenguajes.Models.Domain
{
    public class Fee
    {
        private int idFee;
        private int idTypeVehicle;
        private int idTime;
        private float price;

        public Fee()
        {
        }

        public Fee(int idFee, int idTypeVehicle, int idTime, float price)
        {
            this.idFee = idFee;
            this.idTypeVehicle = idTypeVehicle;
            this.idTime = idTime;
            this.price = price;
        }

        public int IdFee { get => idFee; set => idFee = value; }
        public int IdtypeVehicle { get => idTypeVehicle; set => idTypeVehicle = value; }
        public int IdTime { get => idTime; set => idTime = value; }
        public float Price { get => price; set => price = value; }
    }
}
