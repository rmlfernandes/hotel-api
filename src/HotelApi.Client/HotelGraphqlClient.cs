using System.Net.Http;
using System.Threading.Tasks;
using HotelApi.Entities;
using Newtonsoft.Json;

namespace HotelApi.Client
{
    public class HotelGraphqlClient
    {
        private readonly HttpClient httpClient;

        public HotelGraphqlClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Response<ReservationsResult>> GetReservationsAsync()
        {
            var response = await this.httpClient.GetAsync(
                @"?query={
                reservations {
                checkinDate
                guest  {
                  name
                }
                room {
                  name
                }
              }
            }");

            var stringResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Response<ReservationsResult>>(stringResult);
        }
    }
}
