using System.Collections.Generic;
using System.Threading.Tasks;
using HotelApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HotelApi.Data
{
    public class ReservationRepository
    {
        private readonly MyHotelDbContext _myHotelDbContext;

        public ReservationRepository(MyHotelDbContext myHotelDbContext)
        {
            _myHotelDbContext = myHotelDbContext;
        }

        public async Task<List<Reservation>> GetAll()
        {
            return await _myHotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ToListAsync();
        }

        public IIncludableQueryable<Reservation, Guest> GetQuery()
        {
            return _myHotelDbContext
                 .Reservations
                 .Include(x => x.Room)
                 .Include(x => x.Guest);
        }
    }
}
