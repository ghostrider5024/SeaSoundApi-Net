using SeaSound.Repository.Model;
using SeaSound.Service.Model.Region;

namespace SeaSound.Service.Model.Artist
{
    public class ArtistResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string Gender { get; set; }
        public string RegionId { get; set; }
        public RegionResponse Region { get; set; }

    }
}
