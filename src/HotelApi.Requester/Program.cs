using System;
using System.Net.Http;
using System.Threading.Tasks;
using HotelApi.Client;
using Newtonsoft.Json;

namespace HotelApi.Requester
{
    public static class Program
    {
        public async static Task Main(string[] args)
        {
            Console.WriteLine("Using HotelGraphqlClient..");

            using var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:5001/graphql")
            };

            var client = new HotelGraphqlClient(httpClient);

            var response = await client.GetReservationsAsync();
            response.OnErrorThrowException();

            Console.WriteLine("Got a response..");

            var responseText = JsonConvert.SerializeObject(
                response,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            Console.WriteLine(responseText);

            Console.ReadLine();
        }
    }
}
