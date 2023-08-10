using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SeaSound.Repository.Model
{
    public class User : BaseModel
    {
        [StringLength(255)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Image { get; set; }

        public ICollection<Playlist> Playlists { get; set; }
    }
}
