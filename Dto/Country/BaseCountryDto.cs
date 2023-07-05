﻿using Microsoft.Build.Framework;

namespace HotelListing.API.Dto.Country
{
    public abstract class BaseCountryDto
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
