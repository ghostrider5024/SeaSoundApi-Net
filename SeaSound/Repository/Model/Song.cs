using SeaSound.Repository.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaSound.Repository
{
    [Table("Song")]
    public class Song : BaseModel
    {
        public string Title { get; set; }
        public string? ArtistNames   { get; set; }
        public string? Image { get; set; }
        public string AudioUrl { get; set; }

        [MaxLength(200)]
        public string? Tag { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
    }
}
