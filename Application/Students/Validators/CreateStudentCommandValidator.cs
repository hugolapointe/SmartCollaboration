using Application.Students.Commands;

using FluentValidation;

namespace Application.Students.Validators {

    class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand> {
        public CreateStudentCommandValidator() {
            RuleFor(student => student.DA).NotEmpty();
            RuleFor(student => student.FirstName).NotEmpty();
            RuleFor(student => student.LastName).NotEmpty();
        }
    }
}
