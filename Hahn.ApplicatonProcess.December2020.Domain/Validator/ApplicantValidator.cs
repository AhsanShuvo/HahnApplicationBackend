using FluentValidation;
using Hahn.ApplicatonProcess.December2020.Domain.Interfaces;
using Hahn.ApplicatonProcess.December2020.Domain.Models;

namespace Hahn.ApplicatonProcess.December2020.Domain.Validator
{
    public class ApplicantValidator : AbstractValidator<ApplicantViewModel>
    {
        private readonly ICountryVerificationService _service;

        public ApplicantValidator(ICountryVerificationService service)
        {
            _service = service;

            RuleFor(m => m.Name).MinimumLength(5).WithMessage("Name must contain 5 characters");
            RuleFor(m => m.FamilyName).MinimumLength(5).WithMessage("FamilyName must contain 5 letters");
            RuleFor(m => m.Address).MinimumLength(10).WithMessage("Address must contain 10 characters");
            RuleFor(m => m.EmailAddress).NotEmpty().EmailAddress().WithMessage("EmailAddress is invalid");
            RuleFor(m => m.Age).GreaterThanOrEqualTo(20).LessThanOrEqualTo(60).WithMessage("Age must be between 20 and 60");
            RuleFor(m => m.CountryOfOrigin).MustAsync(async(country, cancellation) => { return await _service.IsValidCountry(country); }).WithMessage("Country is not valid");
        }
    }
}
