namespace SeaSound.Service.Model.Song
{
    public class SongResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? ArtistNames { get; set; }
        public string? Image { get; set; }
        public string AudioUrl { get; set; }
        public string? Tag { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
    }
}
