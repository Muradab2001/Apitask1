using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DTOs.Processor
{
    public class ProcessorListDto
    {
        public int Totalcount { get; set; }
        public List<ProcessorListItemDto> ProcessorListItemDtos { get; set; }
    }
}
