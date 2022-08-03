using p127Api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.Models
{
    public class Phone:BaseEntity
    {
        public string Brand { get; set; }
        public string  Model{ get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public bool Display { get; set; }

        public Processor Processor { get; set; }
        public int? ProcessorId { get; set; }
    }
}
