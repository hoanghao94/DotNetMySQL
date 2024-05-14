using Microsoft.EntityFrameworkCore;

namespace ConnectMySQL.Model
{

    public class AppDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        /*        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
                {
                    var connectionString = "Server=localhost;Port=3306;database=quanlycafe;uid=root;pwd=123456;";


                    if (!optionBuilder.IsConfigured)
                    {
                        // Cấu hình kết nối với MySQL
                        optionBuilder.UseMySql(connectionString,
                            new MySqlServerVersion(new Version(8, 0, 27)),
                            options => options.EnableRetryOnFailure(
                                maxRetryCount: 5,
                            maxRetryDelay: System.TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                                )
                            ); 
                    }
                }*/
    }
}

