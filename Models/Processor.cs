using p127Api.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.Models
{
    public class Processor:BaseEntity
    {
        public string Model { get; set; }
        public decimal GHz { get; set; }
        public  byte Cores { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
