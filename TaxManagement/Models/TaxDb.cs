using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace TaxManagement.Models
{
    public class TaxDb:DbContext
    {
        public string connstr;
        public TaxDb(string connstr)
        {
            this.connstr = connstr;
        }   

        public DbSet<UserProfile> UserProfile {  get; set; }

        public DbSet<TaxHistory> TaxHistory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(connstr);
        }
    }
}
