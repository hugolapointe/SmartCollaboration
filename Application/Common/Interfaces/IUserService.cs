using System;
using System.Threading.Tasks;


namespace Application.Common.Interfaces {

    public interface IUserService {
        Task<string> GetUserNameAsync(Guid userId);

        Task<(IIdentityResult result, Guid userId)> CreateUserAsync(string email, string password);

        Task<IIdentityResult> DeleteUserAsync(Guid userId);
    }
}
