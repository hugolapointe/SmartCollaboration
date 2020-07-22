using System.Linq;
using System.Threading.Tasks;

using Infrastructure.Identity;

using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Persistence {

    public static class ApplicationDbContextSeed {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager) {
            var defaultUser = new ApplicationUser { UserName = "hlapointe@cegepsth.qc.ca", Email = "hlapointe@cegepsth.qc.ca" };

            if (userManager.Users.Any(u => u.UserName != defaultUser.UserName)) {
                await userManager.CreateAsync(defaultUser, "test");
            }
        }
    }
}
