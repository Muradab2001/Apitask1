using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DTOs.Phone
{
    public class PhoneListItemDto
    {
        public int id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
    }
}
