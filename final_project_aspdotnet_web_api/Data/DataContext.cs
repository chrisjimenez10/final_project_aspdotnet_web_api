using final_project_aspdotnet_web_api.Entities;
using Microsoft.EntityFrameworkCore; //Using Entity Framework to connect to our Database

namespace final_project_aspdotnet_web_api.Data
    //This namespace is to connect to our Database and HOLD our Data using Entity Framework Core
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) //This is a constructor
        {
            
        }

        public DbSet <Todos> Todos { get; set; } //
    }
}
