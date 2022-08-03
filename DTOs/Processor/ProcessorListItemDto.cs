using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DTOs.Processor
{
    public class ProcessorListItemDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal GHz { get; set; }
        public byte Cores { get; set; }
    }
}
