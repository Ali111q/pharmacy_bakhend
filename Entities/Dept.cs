using GaragesStructure.Entities;

namespace BackEndStructuer.Entities
{
    public class Dept : BaseEntity<Guid>
    {
        public decimal Value { get; set; }
        public string Name { get; set; }

        public List<Sell> Sells { get; set; }
    }
}
