using System.ComponentModel.DataAnnotations;

namespace SeaSound.Service.Model
{
    public class AlbumResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? ArtistNames { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTimeOffset? ReleaseDate { get; set; }
        public int TotalListen { get; set; }
        public int? HomeRowIndex { get; set; }
        public int? HomeColumnIndex { get; set; }
        public int? BannerIndex { get; set; }
    }
}
