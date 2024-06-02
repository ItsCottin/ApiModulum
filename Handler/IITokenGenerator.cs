#pragma warning disable CS1591
namespace ApiModulum.Handler;
public interface IITokenGenerator
{
    Task<string> GenerateToken(string username);
}