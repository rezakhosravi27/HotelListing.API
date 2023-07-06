using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Models;

namespace HotelListing.API.Repository
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
