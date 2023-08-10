using Microsoft.EntityFrameworkCore;
using SeaSound.Repository.Model;

namespace SeaSound.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Song> Song { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<SongArtist> SongArtist { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<SongPlaylist> SongPlaylists { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<SongAlbum> SongAlbum { get; set; }

        //public DbSet<Playlist> Playlist { get; set; }
        //public DbSet<SongArtist> SongArtist { get; set; }
        //public DbSet<SongPlaylist> SongPlaylist { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One to Many relation between Region and Artist
            modelBuilder.Entity<Artist>()
                .HasOne(pk => pk.Region)
                .WithMany(fk => fk.Artists)
                .HasForeignKey(fk => fk.RegionId);

            // Many to Many relation between Song and Artist
            modelBuilder.Entity<SongArtist>()
                .HasKey(pk => new { pk.SongId, pk.ArtistId });
            modelBuilder.Entity<SongArtist>()
                    .HasOne(t => t.Song)
                    .WithMany(t => t.SongArtists)
                    .HasForeignKey(f => f.SongId);
            modelBuilder.Entity<SongArtist>()
                    .HasOne(t => t.Artist)
                    .WithMany(t => t.SongArtists)
                    .HasForeignKey(f => f.ArtistId);
            
            // Many to Many relation between Song and Playlist
            modelBuilder.Entity<SongPlaylist>()
                .HasKey(pk => new { pk.SongId, pk.PlaylistId });
            modelBuilder.Entity<SongPlaylist>()
                    .HasOne(t => t.Song)
                    .WithMany(t => t.SongPlaylists)
                    .HasForeignKey(f => f.SongId);
            modelBuilder.Entity<SongPlaylist>()
                    .HasOne(t => t.Playlist)
                    .WithMany(t => t.SongPlaylists)
                    .HasForeignKey(f => f.PlaylistId);
            
            // Many to Many relation between Song and Album
            modelBuilder.Entity<SongAlbum>()
                .HasKey(pk => new { pk.SongId, pk.AlbumId });
            modelBuilder.Entity<SongAlbum>()
                    .HasOne(t => t.Song)
                    .WithMany(t => t.SongAlbums)
                    .HasForeignKey(f => f.SongId);
            modelBuilder.Entity<SongAlbum>()
                    .HasOne(t => t.Album)
                    .WithMany(t => t.SongAlbums)
                    .HasForeignKey(f => f.AlbumId);
        }
    }
}
