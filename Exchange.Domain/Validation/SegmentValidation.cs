using Exchange.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Exchange.Domain.Validation
{
    public class SegmentValidation : AbstractValidator<Segment>
    {
        #region [ Constructor ]

        public SegmentValidation()
        {
            RuleFor(entity => entity.Rate).NotNull().WithErrorCode(ErrorCode.AWE001_FieldIsEmpty).WithMessage("Erro segmento");
        }

        #endregion

        #region [ Methods ]

        protected override bool PreValidate(ValidationContext<Segment> context, FluentValidation.Results.ValidationResult result)
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
