using ManageInformation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Infrastructure.Interfaces
{
    public interface GibddInterface
    {
        ICollection<GIBDD> GetGIBDDs();
        GIBDD GetGIBDDsById(int id);
        GIBDD GetGIBDDsByLicense(int license);
        bool CreateGIBDD(GIBDD pfr);
        bool UpdateGIBDD(GIBDD pfr);
        bool DeleteGIBDD(GIBDD pfr);
        bool GIBDDExists(int id);
        bool Save();
    }
}
