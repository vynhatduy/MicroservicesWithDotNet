using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections;

namespace UserWebApi.Data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> otp) : base(otp)
        {
            var roles=new List<Role> ();
            roles.Add(new Role
            {
                Ten = "Administrator",
                MoTa = ""
            });
            roles.Add(new Role
            {
                Ten = "Management",
                MoTa = ""
            });
            roles.Add(new Role
            {
                Ten = "User",
                MoTa = ""
            });
            try
            {
                var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (!dbCreator.CanConnect())
                {
                    dbCreator.Create();
                }
                if (!dbCreator.HasTables())
                {
                    dbCreator.CreateTables();
                    Roles.AddRangeAsync(roles);
                    this.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<UserRole>().Property(x => x.RoleId).IsRequired();
        }
    }
}
