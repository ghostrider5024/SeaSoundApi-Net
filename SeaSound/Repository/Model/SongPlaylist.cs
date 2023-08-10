namespace SeaSound.Repository.Model
{
    public class SongPlaylist : BaseModelWithoutKey
    {
        public string SongId { get; set; }
        public string PlaylistId { get; set; }
        public string? Role { get; set; }

        public Song Song { get; set; }
        public Playlist Playlist { get; set; }
    }
}
