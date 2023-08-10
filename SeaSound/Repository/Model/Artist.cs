using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeaSound.Repository.Model
{
    [Table("Artist")]
    public class Artist : BaseModel
    {
        [Required]
        [StringLength(255)]
        public string FullName { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [StringLength(255)]
        public string? Image { get; set; }

        [StringLength(10)]
        [RegularExpression("Nam|Nữ")]
        public string Gender { get; set; }
        public DateTimeOffset? DebutDate { get; set; }

        public string RegionId { get; set; }
        public Region Region { get; set; }

        public ICollection<SongArtist> SongArtists { get; set; }

    }
}
