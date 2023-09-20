using FluentValidation;
using FluentValidationWebApi.Models;

namespace FluentValidationWebApi.Validators
{
    public class StudentBindingValidator : AbstractValidator<StudentBindingModel>
    {
        public StudentBindingValidator() 
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.SurName).NotEmpty();
            RuleFor(x => x.BirthDay).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now.AddYears(-16)));
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
        }
    }
}
