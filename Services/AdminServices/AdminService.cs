using FoodMartMongo.Entities;
using FoodMartMongo.Settings;
using MongoDB.Driver;
using NuGet.Configuration;

namespace FoodMartMongo.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IMongoCollection<ApplicationUser> _userCollection;

        public AdminService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _userCollection = database.GetCollection<ApplicationUser>(_databaseSettings.AdminCollectionName);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return user.Password == password;
        }

        public async Task<ApplicationUser> GetUserByUserNameAsync(string userName)
        {
            return await _userCollection.Find(x => x.UserName == userName).FirstOrDefaultAsync();
        }

        public async Task RegisterUserAsync(ApplicationUser user)
        {
            await _userCollection.InsertOneAsync(user);
        }
    }
}
