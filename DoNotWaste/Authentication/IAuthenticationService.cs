namespace DoNotWaste.Authentication;

public interface IAuthenticationService
{
    Task<string?> GetEnergyStarToken();
    Task<string?> GetAssetScoreToken();
}