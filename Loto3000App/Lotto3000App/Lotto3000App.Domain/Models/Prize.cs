using Lotto3000App.Domain.Enums;

namespace Lotto3000App.Domain.Models
{
    public class Prize : BaseEntity
    {
        public PrizeTier Tier { get; set; } 
        public string Name { get; set; } = default!;

        public List<Winner> Winners { get; set; }
    }
}
