using IdentityModel;
using IdentityModel.Client;
using IdentityServerTest.ConsoleApp.Implementations;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IdentityServerTest.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            //Ask User
            Console.Write("Username:");
            var username = Console.ReadLine();
            Console.Write("Password:");
            var password = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("With Nuget Package: IdentityServer4.Contrib.HttpClientService");
            HttpClientServiceImplementation.Sample(username, password).GetAwaiter().GetResult();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("With Nuget Package: IdentityModel");
            NativeImplementation.Sample(username, password).GetAwaiter().GetResult();
            Console.WriteLine(new string('-', 80));
            Console.WriteLine();

            Console.ReadKey();
        }

    }
}
