using Microsoft.EntityFrameworkCore;
using MultipleDbContexts.Models;

namespace MultipleDbContexts.Data
{
    public class CharacterDbContext: DbContext
    {
        public CharacterDbContext(DbContextOptions<CharacterDbContext> options): base(options) { }
        
        public DbSet<Character> Characters { get; set; }
    }
}
