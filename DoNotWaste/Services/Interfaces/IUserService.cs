namespace DoNotWaste.Services.Interfaces;

public interface IUserService
{
    Task<HttpResponse> GetUser();
    Task<HttpResponse> CreateUser(Account account);
}