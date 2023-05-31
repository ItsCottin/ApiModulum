using System.Security.Cryptography;
using WebApiModulum.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApiModulum.Handler;

public class RefreshTokenGenerator : IRefreshTokenGenerator
{
    private readonly ModulumContext dbContext;
    public RefreshTokenGenerator(ModulumContext _dbContext)
    {
        this.dbContext = _dbContext;
    }

    public DateTime getDateValidade()
    {
        return DateTime.Now.AddMinutes(10);
    }
    public async Task<string> GenerateToken(string username)
    {
        var randomnumber = new byte[32];
        using(var randomnumbergenerator = RandomNumberGenerator.Create())
        {
            randomnumbergenerator.GetBytes(randomnumber);
            string refreshtoken = Convert.ToBase64String(randomnumber);
            var token = await this.dbContext.RefreshToken.FirstOrDefaultAsync(item => item.loginUsu == username);
            if(token != null)
            {
                token.refreshToken = refreshtoken;
                token.dateValidade = getDateValidade();
            }
            else
            {
                this.dbContext.RefreshToken.Add(new RefreshToken()
                {
                    loginUsu = username,
                    idToken = new Random().Next().ToString(),
                    refreshToken = refreshtoken,
                    isActive = true,
                    dateValidade = getDateValidade()
                });
            }
            await this.dbContext.SaveChangesAsync();
            return refreshtoken;
        }
    }
}