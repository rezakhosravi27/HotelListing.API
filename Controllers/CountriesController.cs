
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelListing.API.Models;
using HotelListing.API.Dto.Country;
using AutoMapper;
using HotelListing.API.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
      
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;

        public CountriesController( IMapper mapper, ICountryRepository countryRepository)
        {
            _mapper = mapper;
            _countryRepository = countryRepository; 
        }

        // GET: api/Countries
        [HttpGet]
        [ResponseCache(Duration = 20)]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _countryRepository.GetAllAsync(); 
            var records = _mapper.Map<IEnumerable<GetCountryDto>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _countryRepository.GetDetails(id); 
            var record = _mapper.Map<CountryDto>(country); 

            if (country == null)
            {
                return NotFound();
            }

            return Ok(record);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountry)
        {
            if (id != updateCountry.Id)
            {
                return BadRequest();
            }

            //_context.Entry(country).State = EntityState.Modified;
            var country = await _countryRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountry, country); 

            try
            {
                await _countryRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountryDto createCountry)
        {
            var country = _mapper.Map<Country>(createCountry);

            await _countryRepository.AddAsync(country); 

            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var result = await _countryRepository.GetAsync(id); 
            if(result == null)
            {
                return NotFound();
            }

            await _countryRepository.DeleteAsync(id); 

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countryRepository.Exist(id);
        }
    }
}
