using ManageInformation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Infrastructure.Interfaces
{
    public interface NalogovayaInterface
    {
        ICollection<Nalogovaya> GetNalogovayas();
        Nalogovaya GetNalogovayasById(int id);
        Nalogovaya GetNalogovayasByINN(int inn);
        bool CreateNalogovaya(Nalogovaya Nalogovaya);
        bool UpdateNalogovaya(Nalogovaya Nalogovaya);
        bool DeleteNalogovaya(Nalogovaya Nalogovaya);
        bool NalogovayaExists(int id);
        bool Save();
    }
}
