using Exchange.Domain.Validation;

namespace Exchange.Domain.Entities
{
    public class Country : EntityBase
    {
        public string Name { get; set; }
        public string Currency { get; set; }

        public override bool Validate()
        {
            return Validate(this, new CountryValidation());
        }
    }
}
