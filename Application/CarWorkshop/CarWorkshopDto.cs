﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarWorkshop
{
    public class CarWorkshopDto
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; } = default!;
        [Required]
        public string? Description { get; set; }
        [Phone]
        [StringLength(12, MinimumLength = 9)]
        public string? PhoneNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? EncodedName { get; set; }
    }
}
