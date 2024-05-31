using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsers();
    }
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;
        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var userResponse = await _httpClient.GetAsync("http://example.com");
            return new List<User>{ };
        }
    }
}
