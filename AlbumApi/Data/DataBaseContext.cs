using Microsoft.EntityFrameworkCore;

namespace AlbumApi.Data
{
    public class DataBaseContext : DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { }

        public DbSet<Album> album { get; set; }
        public DbSet<Artista> artista { get; set; }
        public DbSet<Genero> genero { get; set; }

    }
}
