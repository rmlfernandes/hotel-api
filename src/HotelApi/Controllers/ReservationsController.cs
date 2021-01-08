using System.Collections.Generic;
using System.Threading.Tasks;
using HotelApi.Data;
using HotelApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HotelApi.Controllers
{
    [Route("api/reservations")]
    public class GraphQLController : Controller
    {
        private readonly ReservationRepository reservationRepository;

        public GraphQLController(ReservationRepository reservationRepository)
        {
            this.reservationRepository = reservationRepository;
        }

        [HttpGet]
        public async Task<List<Reservation>> List()
        {
            return await this.reservationRepository.GetAll();
        }
    }
}
