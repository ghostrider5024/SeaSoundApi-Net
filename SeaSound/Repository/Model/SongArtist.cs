using System.ComponentModel.DataAnnotations.Schema;

namespace SeaSound.Repository.Model
{
    [Table(nameof(SongArtist))]
    public class SongArtist : BaseModelWithoutKey
    {
        public string SongId { get; set; }
        public string ArtistId { get; set; }
        public string? Role { get; set; }

        public Song Song { get; set; }
        public Artist Artist { get; set; }
    }
}
