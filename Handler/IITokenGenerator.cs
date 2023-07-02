#pragma warning disable CS1591
namespace WebApiModulum.Handler;
public interface IITokenGenerator
{
    Task<string> GenerateToken(string username);
}