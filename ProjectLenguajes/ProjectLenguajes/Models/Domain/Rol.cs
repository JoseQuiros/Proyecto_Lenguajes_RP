namespace ProjectLenguajes.Models.Domain
{
    public class Rol
    {
        private int idRol;
        private string name;
        private int authority;
        public Rol()
        {
        }

        public Rol(int idRol, string name, int authority)
        {
            this.idRol = idRol;
            this.name = name;
            this.authority = authority;
        }

        public int IdRol { get => idRol; set => idRol = value; }
        public string Name { get => name; set => name = value; }
        public int Authority { get => authority; set => authority = value; }
    }
}
