using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace p127Api.DTOs.Phone
{
    public class PhoneListDto
    {
        public List<PhoneListItemDto> PhoneListItemDtos { get; set; }
        public int Totalcount { get; set; }
    }
}
