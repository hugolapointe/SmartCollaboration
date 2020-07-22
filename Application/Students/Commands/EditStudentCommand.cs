using System;

using Core.ValueObjects;

using MediatR;

namespace Application.Students.Commands {

    public class UpdateStudentCommand : IRequest {
        public Guid Id { get; set; }

        public string DA { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
