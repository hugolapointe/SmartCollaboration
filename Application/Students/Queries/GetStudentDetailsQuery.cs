using System;

using Application.Students.Responses;

using MediatR;

namespace Application.Students.Queries {

    public class GetStudentDetailsQuery : IRequest<StudentDetails> {
        public Guid Id { get; set; }
    }
}
