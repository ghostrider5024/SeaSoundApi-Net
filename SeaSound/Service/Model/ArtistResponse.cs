using SeaSound.Repository.Model;

namespace SeaSound.Service.Model
{
    public class ArtistResponse
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string Gender { get; set; }
        public string RegionId { get; set; }
        public Region Region { get; set; }

    }
}
