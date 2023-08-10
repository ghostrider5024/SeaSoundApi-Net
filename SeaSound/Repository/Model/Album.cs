using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SeaSound.Repository.Model
{
    public class Album : BaseModel
    {
        [StringLength(255)]
        public string Title { get; set; }

        public string? ArtistNames { get; set; }

        public string Description { get; set; }
       
        public string Image { get; set; }

        public DateTimeOffset? ReleaseDate { get; set; }

        public int TotalListen { get; set; }
        public int? HomeRowIndex { get; set; }
        public int? HomeColumnIndex { get; set; }
        public int? BannerIndex { get; set; }

        public ICollection<SongAlbum> SongAlbums { get; set; }
    }
}
