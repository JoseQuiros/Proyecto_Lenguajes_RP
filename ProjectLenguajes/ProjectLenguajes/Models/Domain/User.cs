namespace ProjectLenguajes.Models.Domain
{
    public class User
    {

        private int idUser;
        private int idRol;
        private string name;
        private string dni;
        private int age;
        private string telephone;
        private string email;
        private string password;

        public User()
        {
        }

        public User(int idUser, int idRol, string name, string dni, int age, string telephone, string email, string password)
        {
            this.idUser = idUser;
            this.idRol = idRol;
            this.name = name;
            this.dni = dni;
            this.age = age;
            this.telephone = telephone;
            this.email = email;
            this.password = password;
        }

        public int IdUser { get => idUser; set => idUser = value; }
        public int IdRol { get => idRol; set => idRol = value; }
        public string Name { get => name; set => name = value; }
        public string Dni { get => dni; set => dni = value; }
        public int Age { get => age; set => age = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
