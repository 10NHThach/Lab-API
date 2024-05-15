using Microsoft.AspNetCore.Identity;

namespace LabAPI.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
