using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BopodaMVP
{
    public class AzureADB2COpenIdConnectOptionsConfigurator : IConfigureNamedOptions<OpenIdConnectOptions>
    {
        private readonly AzureADB2CWithApiOptions _options;

        public AzureADB2COpenIdConnectOptionsConfigurator(IOptions<AzureADB2CWithApiOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public void Configure(string name, OpenIdConnectOptions options)
        {
            options.Events.OnAuthorizationCodeReceived = WrapOpenIdConnectEvent(options.Events.OnAuthorizationCodeReceived, OnAuthorizationCodeReceivedAsync);
            options.Events.OnRedirectToIdentityProvider = WrapOpenIdConnectEvent(options.Events.OnRedirectToIdentityProvider, OnRedirectToIdentityProviderAsync);
        }

        public void Configure(OpenIdConnectOptions options)
        {
            Configure(Options.DefaultName, options);
        }

        private static Func<TContext, Task> WrapOpenIdConnectEvent<TContext>(Func<TContext, Task> baseEventHandler, Func<TContext, Task> thisEventHandler)
        {
            return new Func<TContext, Task>(async context =>
            {
                await baseEventHandler(context);
                await thisEventHandler(context);
            });
        }

        private async Task OnAuthorizationCodeReceivedAsync(AuthorizationCodeReceivedContext context)
        {
            var userId = context.Principal.FindFirst(ClaimTypes.NameIdentifier).Value;
            var referers = context.HttpContext.Request.Headers["Referer"].ToString().Split('/').FirstOrDefault(t => t.ToLower().StartsWith("b2c_1")).ToLower();
            var authority = context.Options.Authority.Replace("b2c_1_susi", referers);

            var confidentialClientApplication = ConfidentialClientApplicationBuilder
                .Create(context.Options.ClientId)
                .WithClientSecret(context.Options.ClientSecret)
                .WithAuthority(authority)
                .WithRedirectUri(_options.RedirectUri)
                .Build();

            try
            {
                var authenticationResult = await confidentialClientApplication
                    .AcquireTokenByAuthorizationCode(_options.ApiScopes.Split(' '), context.ProtocolMessage.Code)
                    .WithB2CAuthority(authority)
                    .ExecuteAsync();
                context.HandleCodeRedemption(authenticationResult.AccessToken, authenticationResult.IdToken);
            }
            catch (Exception ex)
            {
                // TODO: Handle
                //throw ex;
            }
        }

        private Task OnRedirectToIdentityProviderAsync(RedirectContext context)
        {
            context.ProtocolMessage.ResponseType = OpenIdConnectResponseType.CodeIdToken;
            context.ProtocolMessage.Scope += $" offline_access {_options.ApiScopes}";
            return Task.FromResult(0);
        }
    }
}
