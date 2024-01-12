using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Domain.Model
{
    public class GIBDD
    {
        public int Id { get; set; }
        public int License { get; set; }
        public string Category { get; set; } = String.Empty;
        //public ICollection<Cars> Cars { get; set; }
    }
}
