using System.ComponentModel.DataAnnotations;

namespace SeaSound.Repository.Model
{
    public class Playlist : BaseModel
    {
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string? Description { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public ICollection<SongPlaylist> SongPlaylists { get; set; }
    }
}
