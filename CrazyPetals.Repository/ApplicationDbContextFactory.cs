using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace CrazyPetals.Repository
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            //builder.UseMySql("server=165.22.60.17;port=3306;uid=admin;password=Omni#1234$;database=CrazyPetalsDB_test;",
            builder.UseMySql("server=localhost;port=3306;uid=root;password=Reset1234;database=CrazyPetalsDB_test;",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new ApplicationDbContext(builder.Options);
        }
    }
}
