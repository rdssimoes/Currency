using Exchange.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Exchange.Domain.Validation
{
    public class RateValidation : AbstractValidator<Rate>
    {
        #region [ Constructor ]

        public RateValidation()
        {
            RuleFor(entity => entity.Currency).NotNull().WithErrorCode(ErrorCode.AWE001_FieldIsEmpty).WithMessage("Erro Rate");
        }

        #endregion

        #region [ Methods ]

        protected override bool PreValidate(ValidationContext<Rate> context, FluentValidation.Results.ValidationResult result)
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
