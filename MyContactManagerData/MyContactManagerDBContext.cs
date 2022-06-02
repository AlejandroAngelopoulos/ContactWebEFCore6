using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyContactManagerData
{
    public class MyContactManagerDBContext : DbContext
    {
        private static IConfigurationRoot _configuration;
        
        public MyContactManagerDBContext()
        {
            //purposefully empty but necessary for Scaffold

        }
        
        public MyContactManagerDBContext(DbContextOptions options) : base(options)
        {
            //purposefully empty but necessary to set options properly
        }

        protected override OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional:true ,reloadOnChange:true);
            _configuration = builder.Build();
            var constr = _configuration.GetConnectionString("MyContactManager");
            optionsBuilder.UseSqlServer(constr);

        }
    }
}