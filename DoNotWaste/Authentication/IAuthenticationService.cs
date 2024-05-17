namespace DoNotWaste.Authentication;

public interface IAuthenticationService
{
    Task<string?> GetToken();
}