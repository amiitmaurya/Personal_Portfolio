namespace Portfolio_MVC.Models
{
    public class Reg
    {
        public int Id { get; set; }   // PK by convention
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}