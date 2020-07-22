using System.Threading;
using System.Threading.Tasks;

using Application.Common.Interfaces;
using Application.Students.Commands;

using MediatR;

namespace Application.Students.Handlers {

    public class DeleteStudentCommandHandler : AsyncRequestHandler<DeleteStudentCommand> {
        private readonly IApplicationDbContext context;


        public DeleteStudentCommandHandler(IApplicationDbContext context) {
            this.context = context;
        }


        protected async override Task Handle(DeleteStudentCommand request, CancellationToken cancellationToken) {
            var student = context.Students.Find(request.Id);
            context.Students.Remove(student);

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
