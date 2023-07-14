using AutoMapper;
using HotelListing.API.Contracts;
using HotelListing.API.Data;
using HotelListing.API.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.API.Repository
{
    public class CountryRepository: GenericRepository<Country>, ICountryRepository
    {
        private readonly DatabaseContext _context; 
        public CountryRepository(DatabaseContext context, IMapper mapper): base(context, mapper)
        {
            _context = context; 
        }

        public async Task<Country> GetDetails(int id)
        {
            return await _context.Countries.Include(q => q.Hotels).FirstOrDefaultAsync(q => q.Id == id); 
        }
    }
}
