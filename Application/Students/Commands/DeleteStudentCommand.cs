using System;

using MediatR;

namespace Application.Students.Commands {

    public class DeleteStudentCommand : IRequest {
        public Guid Id { get; set; }
    }
}
