using DoNotWaste.Services.Interfaces;

namespace DoNotWaste.Services;

public class UserService : IUserService
{
    public Task<HttpResponse> GetUser()
    {
        throw new NotImplementedException();
    }

    public Task<HttpResponse> CreateUser(Account account)
    {
        throw new NotImplementedException();
    }
}