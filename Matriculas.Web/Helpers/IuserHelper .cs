namespace Matriculas.Web.Helpers
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using Matriculas.Web.Data.Entities;
    using Matriculas.Web.Models;

    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(User user, string roleName);

        Task<bool> IsUserInRoleAsync(User user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();

        Task<SignInResult> ValidatePasswordAsync(User user, string password);

    }


}
