using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Domain.Model
{
    public class Person
    {
        public int Id { get; set; }
        public int MVDId { get; set; } // Идентификатор для MVD
        public int NalogovayaId { get; set; } // Идентификатор для Nalogovaya
        public int GIBDDId { get; set; } // Идентификатор для GIBDD
        public int PFRId { get; set; } // Идентификатор для PFR

        public MVD MVD { get; set; }
        public Nalogovaya Nalogovaya { get; set; }
        public GIBDD GIBDD { get; set; }
        public PFR PFR { get; set; }
    }

}
