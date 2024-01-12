using ManageInformation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Infrastructure.DTO
{
    public class GibddDto
    {
        public int License { get; set; }
        public string Category { get; set; } = String.Empty;
    }
}
