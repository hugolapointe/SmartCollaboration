using System.Threading;
using System.Threading.Tasks;

using Application.Common.Interfaces;
using Application.Students.Commands;

using Core.ValueObjects;

using MediatR;

namespace Application.Students.Handlers {
    public class UpdateStudentCommandHandler : AsyncRequestHandler<UpdateStudentCommand> {
        private readonly IApplicationDbContext context;


        public UpdateStudentCommandHandler(IApplicationDbContext context) {
            this.context = context;
        }


        protected async override Task Handle(UpdateStudentCommand request, CancellationToken cancellationToken) {
            var student = context.Students.Find(request.Id);
            student.DA = DaNumber.Parse(request.DA);
            student.FirstName = request.FirstName;
            student.LastName = request.LastName;

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
