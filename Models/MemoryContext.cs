using Microsoft.EntityFrameworkCore;

namespace memory_words.Models
{
    public class MemoryContext : DbContext

    {
        public MemoryContext(DbContextOptions<MemoryContext> options)
        : base(options)
        { }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Word> Words { get; set; }

    }
}
