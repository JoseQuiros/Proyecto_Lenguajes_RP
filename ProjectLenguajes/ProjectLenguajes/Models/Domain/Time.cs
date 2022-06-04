namespace ProjectLenguajes.Models.Domain
{
    public class Time
    {

        private int idTime;
        private string name;

        public Time()
        {
        }

        public Time(int idTime, string name)
        {
            this.idTime = idTime;
            this.name = name;
        }

        public int IdTime { get => idTime; set => idTime = value; }
        public string Name { get => name; set => name = value; }

    }
}
    
        

