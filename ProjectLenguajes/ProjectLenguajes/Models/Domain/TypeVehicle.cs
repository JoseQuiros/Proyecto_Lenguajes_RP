namespace ProjectLenguajes.Models.Domain
{
    public class TypeVehicle
    {
        private int idType;
        private string name;

        public TypeVehicle()
        {
        }

        public TypeVehicle(int idType, string name)
        {
            this.idType = idType;
            this.name = name;
        }

        public int IdType { get => idType; set => idType = value; }
        public string Name { get => name; set => name = value; }
    }
}
