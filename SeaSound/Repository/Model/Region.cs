using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SeaSound.Repository.Model
{
    [Table(nameof(Region))]
    public class Region : BaseModel
    {
        [Required]
        [MaxLength(50)]
        public string RegionName { get; set; }

        public ICollection<Artist> Artists { get; set; }
    }
}
