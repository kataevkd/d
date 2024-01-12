using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Domain.Model
{
    public class Cars
    {
        public int Id { get; set; }
        public string CarNumber { get; set; } = String.Empty;
        public GIBDD OwnerLicense { get; set; }

        public int OwnerLicenseId { get; set; }
        
        public string CarMarka { get; set; } = String.Empty;
    }
}
