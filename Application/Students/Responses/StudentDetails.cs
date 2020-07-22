using System;

using Application.Common.Mappings;

using Core.Entities;

namespace Application.Students.Responses {

    public class StudentDetails : IMapFrom<Student> {
        public Guid Id { get; set; }
        public string DA { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
