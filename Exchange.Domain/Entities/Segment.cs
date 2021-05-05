using Exchange.Domain.Validation;

namespace Exchange.Domain.Entities
{
    public class Segment : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }

        public override bool Validate()
        {
            return Validate(this, new SegmentValidation());
        }
    }
}
