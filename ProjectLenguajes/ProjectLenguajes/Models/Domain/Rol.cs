namespace ProjectLenguajes.Models.Domain
{
    public class Rol
    {
        private int idRol;
        private string name;

        public Rol()
        {
        }

        public Rol(int idRol, string name)
        {
            this.idRol = idRol;
            this.name = name;
        }

        public int IdRol { get => idRol; set => idRol = value; }
        public string Name { get => name; set => name = value; }
    }
}
