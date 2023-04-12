using Microsoft.EntityFrameworkCore;

namespace ogrenci_kayit.Models
{
    public class StudentContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:ogrencikayitConnection"]);
        }

        public DbSet<Student> Students { get; set; }
    }
}
