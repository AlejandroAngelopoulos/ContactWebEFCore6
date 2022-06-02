using ContactWebModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MyContactManagerData
{
    public class MyContactManagerDBContext : DbContext
    {
        private static IConfigurationRoot _configuration;

        public DbSet<State> States{ get; set; }
        public DbSet<Contact> Contacts { get; set; }


        public MyContactManagerDBContext()
        {
            //purposefully empty but necessary for Scaffold

        }
        
        public MyContactManagerDBContext(DbContextOptions options) : base(options)
        {
            //purposefully empty but necessary to set options properly
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json", optional:true ,reloadOnChange:true);
            _configuration = builder.Build();
            var constr = _configuration.GetConnectionString("MyContactManager");
            optionsBuilder.UseSqlServer(constr);
           

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>(x => {x.HasData(
            
                new State() { Id = 1, Name = "Attica", Abbreviation = "AT" },
                new State() { Id = 2, Name = "Achaia", Abbreviation = "AC" },
                new State() { Id = 3, Name = "Thessaloniki", Abbreviation = "TH" },
                new State() { Id = 4, Name = "Irakleiou", Abbreviation = "IR" });

            });
                                             
        
        }
    }
}