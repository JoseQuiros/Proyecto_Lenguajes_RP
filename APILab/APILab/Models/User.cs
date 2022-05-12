namespace APILab.Models
{
    public partial class User
    {
        public int IDuser { get; set; }
        public int IDrol { get; set; }
        public string Name { get; set; } = null!;
        public string DNI { get; set; } = null!;
        public int Age { get; set; }
        public string Telephone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        
    }
}
