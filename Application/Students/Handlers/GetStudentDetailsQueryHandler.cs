using System.Threading;
using System.Threading.Tasks;

using Application.Common.Interfaces;
using Application.Students.Queries;
using Application.Students.Responses;

using AutoMapper;

using MediatR;

namespace Application.Students.Handlers {

    public class GetStudentDetailsQueryHandler : IRequestHandler<GetStudentDetailsQuery, StudentDetails> {
        private readonly IMapper mapper;
        private readonly IApplicationDbContext context;


        public GetStudentDetailsQueryHandler(IMapper mapper, IApplicationDbContext context) {
            this.mapper = mapper;
            this.context = context;
        }


        public async Task<StudentDetails> Handle(GetStudentDetailsQuery request, CancellationToken cancellationToken) {
            var student = await context.Students.FindAsync(request.Id);

            return mapper.Map<StudentDetails>(student);
        }
    }
}
