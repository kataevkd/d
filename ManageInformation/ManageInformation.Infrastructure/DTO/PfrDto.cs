using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Infrastructure.DTO
{
    public class PfrDto
    {
        //public int Id { get; set; }
        public int SNILS { get; set; }
        public int WorkBook { get; set; }
        public string SocialStatus { get; set; } = String.Empty;
    }
}
