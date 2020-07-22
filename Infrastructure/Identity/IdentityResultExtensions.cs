using System.Linq;

using Application.Common.Interfaces;

namespace Infrastructure.Identity {

    public static class IdentityResultExtensions {
        public static IIdentityResult ToApplicationResult(this Microsoft.AspNetCore.Identity.IdentityResult result) {
            return result.Succeeded ?
                Application.Common.Models.IdentityResult.Success() :
                Application.Common.Models.IdentityResult.Failure(result.Errors.Select(e => e.Description));
        }
    }
}
