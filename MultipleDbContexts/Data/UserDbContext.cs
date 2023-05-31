using Microsoft.EntityFrameworkCore;
using MultipleDbContexts.Models;

namespace MultipleDbContexts.Data
{
    public class UserDbContext: DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
