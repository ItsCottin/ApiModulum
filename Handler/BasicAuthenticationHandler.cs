#pragma warning disable CS1591
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;
using System.Text;
using ApiModulum.Models;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace ApiModulum.Handler
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private readonly ModulumContext _DBContext;
        public BasicAuthenticationHandler
            (
                IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, ModulumContext dBContext
            ): base(options, logger, encoder, clock)
        {
            this._DBContext = dBContext;
        }

        protected async override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Não foi possível encontrar o Header da Requisição.");
            }

            var _headervalue = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var bytes = Convert.FromBase64String(_headervalue.Parameter);
            string credentials = Encoding.UTF8.GetString(bytes);

            if (!string.IsNullOrEmpty(credentials))
            {
                string[] array = credentials.Split(":");
                string username = array[0];
                string password = array[1];
                var user = this._DBContext.Usuario.FirstOrDefault(item=>item.Login == username && item.Senha == password);

                if (user == null)
                {
                    return AuthenticateResult.Fail("Não Autorizado para o Usuario e Senha do Header");
                }

                var claim = new[]{new Claim(ClaimTypes.Name, username)};
                var identity = new ClaimsIdentity(claim, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Não foi possível encontrar o Header da Requisição.");
            }
        }
    }
}
