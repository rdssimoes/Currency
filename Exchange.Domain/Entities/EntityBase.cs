using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Exchange.Domain.Entities
{
    public abstract class EntityBase
    {
        public bool IsValid { get; private set; }

        protected ValidationResult ValidationResult { get; private set; }
        public IList<ExchangeExceptionType> Errors { get; private set; }

        protected bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            Errors = (from error in ValidationResult.Errors select new ExchangeExceptionType(error.ErrorCode, error.ErrorMessage)).ToList();
            return IsValid = ValidationResult.IsValid;
        }

        public abstract bool Validate();
    }
}
