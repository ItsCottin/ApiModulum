#pragma warning disable CS1591
using System.Security.Cryptography;
using ApiModulum.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiModulum.Handler;

public class ITokenGenerator : IITokenGenerator
{
    private readonly ModulumContext dbContext;
    public ITokenGenerator(ModulumContext _dbContext)
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
            string iToken = Convert.ToBase64String(randomnumber);
            var token = await this.dbContext.IToken.FirstOrDefaultAsync(item => item.loginUsu == username);
            if(token != null)
            {
                token.iToken = iToken;
                token.dateValidade = getDateValidade();
            }
            else
            {
                this.dbContext.IToken.Add(new IToken()
                {
                    loginUsu = username,
                    idToken = new Random().Next().ToString(),
                    iToken = iToken,
                    isActive = true,
                    dateValidade = getDateValidade()
                });
            }
            await this.dbContext.SaveChangesAsync();
            return iToken;
        }
    }
}