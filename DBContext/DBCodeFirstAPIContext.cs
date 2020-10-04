using CodeFirst_API.DBModels;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst_API.DBContext
{
    public class DBCodeFirstApiContext : DbContext
    {
        public DbSet<Client> Client { get; set; }

        public DbSet<ClientCategory> ClientCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-4DQOEQH\SQLEXPRESS1;DataBase=CodeFirstBD;Trusted_Connection=True;");
        }
    }


}
