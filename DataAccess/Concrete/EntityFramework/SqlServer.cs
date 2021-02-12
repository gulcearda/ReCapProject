using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class SqlServer : DbContext
    {
        //projenin hangi veri tabanıyla ilişkili olduğunu gösterir.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=175.45.2.12; Database=SqlServer; Trusted_Connection=true");
            //Sql serverın bulunduğu ip adresi yazılı bende hala yok Macbook:(
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }

    }
}
