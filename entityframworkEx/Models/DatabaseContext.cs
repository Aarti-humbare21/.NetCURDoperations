using Microsoft.EntityFrameworkCore;

namespace entityframworkEx.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext>options):base(options) {
        }

        public virtual DbSet<RegisterModel> RegisterModel { get; set; }
        public virtual DbSet<t1> t1 { get; set; }

    }
}
