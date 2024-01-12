using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Infrastructure.DTO
{
    public class NalogovayaDto
    {
        //public int Id { get; set; }
        public int INN { get; set; }
        public string property { get; set; } = String.Empty;
        public string bills { get; set; } = String.Empty;
    }
}
