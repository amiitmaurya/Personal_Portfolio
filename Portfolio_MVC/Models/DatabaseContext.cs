using System.Data.Entity;

namespace Portfolio_MVC.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("name=abc")
        {

        }

        public DbSet<Reg> Regs { get; set; }
        public DbSet<Contact_me> Contact_mes { get; set; }
    }
}