using System.ComponentModel.DataAnnotations;

namespace SeaSound.Repository.Model
{
    public class BaseModel : BaseModelWithoutKey
    {
        [Key]
        public string Id { get; set; }
    }

    public class BaseModelWithoutKey
    {
        public DateTimeOffset? DeleteDate { get; set; }
    }
}
