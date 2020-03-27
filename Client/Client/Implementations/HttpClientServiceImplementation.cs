using IdentityModel;
using IdentityModel.Client;
using IdentityServer4.Contrib.HttpClientService;
using IdentityServer4.Contrib.HttpClientService.Extensions;
using IdentityServer4.Contrib.HttpClientService.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IdentityServerTest.ConsoleApp.Implementations
{
    public static class HttpClientServiceImplementation
    {
        public static async Task Sample(string username, string password)
        {
            //Make the call
            var responseObject = await HttpClientServiceFactory
                .Instance
                .CreateHttpClientService()
                .SetIdentityServerOptions<PasswordOptions>(x =>
                {
                    x.Address = "http://localhost:5000/connect/token";
                    x.ClientId = "ConsoleApp_ClientId";
                    x.ClientSecret = "secret_for_the_consoleapp";
                    x.Scope = "ApiName";

                    x.Username = username;
                    x.Password = password.ToSha256();
                })
                .GetAsync("https://localhost:44328/api/values");
            

                //Check the result
                if (!responseObject.HasError)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Console.WriteLine("SUCCESS!!");
                    Console.WriteLine();
                    Console.WriteLine("Access Token: ");
                    Console.WriteLine(responseObject.HttpRequestMessge.Headers.Authorization.Parameter);

                    Console.WriteLine();
                    Console.WriteLine("API response:");
                    Console.WriteLine(responseObject.BodyAsString);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Failed to login with error:");
                    Console.WriteLine(responseObject.Error);
                }

        }
    }
}
