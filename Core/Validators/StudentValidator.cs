using Core.Entities;

using FluentValidation;

namespace Core.Validators {

    public class StudentValidator : AbstractValidator<Student> {
        public StudentValidator() {
            RuleFor(s => s.DA).NotEmpty();
            RuleFor(s => s.FirstName).NotEmpty();
            RuleFor(s => s.LastName).NotEmpty();
        }
    }
}
