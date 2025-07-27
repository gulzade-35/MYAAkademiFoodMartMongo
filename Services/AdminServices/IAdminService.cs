using FoodMartMongo.Entities;

namespace FoodMartMongo.Services.AdminServices
{
    public interface IAdminService
    {
        Task RegisterUserAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByUserNameAsync(string userName);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
    }
}
