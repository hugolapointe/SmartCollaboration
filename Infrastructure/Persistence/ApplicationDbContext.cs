using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

using Application.Common.Interfaces;

using Core.Common;
using Core.Entities;

using Infrastructure.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence {

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext {
        private readonly ICurrentUserService currentUserService;
        private readonly IDateTimeService dateTimeService;

        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Course> Courses { get; set; }

        public ApplicationDbContext(
            DbContextOptions options,
            ICurrentUserService currentUserService,
            IDateTimeService dateTimeService) :
            base(options) {
            this.currentUserService = currentUserService;
            this.dateTimeService = dateTimeService;
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
            UpdateAuditableEntities();

            return base.SaveChangesAsync(cancellationToken);
        }


        private void UpdateAuditableEntities() {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>()) {
                switch (entry.State) {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = currentUserService.UserId.ToString();
                        entry.Entity.Created = dateTimeService.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = currentUserService.UserId.ToString();
                        entry.Entity.LastModified = dateTimeService.Now;
                        break;
                }
            }
        }
    }
}
