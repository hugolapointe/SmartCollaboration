using System.Threading;
using System.Threading.Tasks;

using Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces {

    public interface IApplicationDbContext {
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Course> Courses { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
