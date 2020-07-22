using Core.ValueObjects;

using MediatR;

namespace Application.Students.Commands {
    public class CreateStudentCommand : IRequest {
        public string DA { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
