using System.Threading;
using System.Threading.Tasks;

using Application.Common.Interfaces;
using Application.Students.Commands;

using AutoMapper;

using Core.Entities;
using Core.ValueObjects;

using MediatR;

namespace Application.Students.Handlers {

    public class CreateStudentCommandHandler : AsyncRequestHandler<CreateStudentCommand> {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public CreateStudentCommandHandler(IApplicationDbContext context) {
            this.context = context;
        }


        protected async override Task Handle(CreateStudentCommand request, CancellationToken cancellationToken) {
            var student = new Student() {
                DA = DaNumber.Parse(request.DA),
                FirstName = request.FirstName,
                LastName = request.LastName
            };
            context.Students.Add(student);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
