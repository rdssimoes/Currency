using Exchange.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Exchange.Domain.Validation
{
    public class CountryValidation : AbstractValidator<Country>
    {
        #region [ Constructor ]

        public CountryValidation()
        {
            RuleFor(entity => entity.Currency).NotNull().WithErrorCode(ErrorCode.AWE001_FieldIsEmpty).WithMessage("Erro Country");
        }

        #endregion

        #region [ Methods ]

        protected override bool PreValidate(ValidationContext<Country> context, FluentValidation.Results.ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Object null"));
                return false;
            }
            return true;
        }

        #endregion
    }
}
