namespace WebApiModulum.Handler;
public interface IRefreshTokenGenerator
{
    Task<string> GenerateToken(string username);
}