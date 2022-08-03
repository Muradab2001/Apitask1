using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using p127Api.Models;

namespace p127Api.DTOs.Processor
{
    public class ProcessorGetDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal GHz { get; set; }
        public byte Cores { get; set; }
    }
}
