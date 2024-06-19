using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Json;
using UpSoluctions.Web.Response;

namespace UpSoluctions.Web.Services
{
    public class AuthAPI(IHttpClientFactory factory) : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient = factory.CreateClient("Auth");

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponse> LoginAsync(string email, string password)
        {
            var response = await _httpClient.PostAsJsonAsync("/api/login?useCookies=true", new
            {
                email,
                password
            });

            var responseContent = await response.Content.ReadFromJsonAsync<TokenResponse>();

            //TODO

            if (response.IsSuccessStatusCode)
            {
                return new AuthResponse { Sucesso = true };
            }

            return new AuthResponse { Sucesso = false, Erros = ["Login/Senha inválidos"] };
        }
    }
}
