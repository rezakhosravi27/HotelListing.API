﻿using AutoMapper;
using HotelListing.API.Dto.Country;
using HotelListing.API.Dto.Hotels;
using HotelListing.API.Models;

namespace HotelListing.API.Configurations
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            CreateMap<Hotel, HotelDto>().ReverseMap();
        }
    }
}
