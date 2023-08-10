namespace SeaSound.Repository.Model
{
    public class SongAlbum : BaseModelWithoutKey
    {
        public string SongId { get; set; }
        public string AlbumId { get; set; }
        public string? Role { get; set; }

        public Song Song { get; set; }
        public Album Album { get; set; }
    }
}
