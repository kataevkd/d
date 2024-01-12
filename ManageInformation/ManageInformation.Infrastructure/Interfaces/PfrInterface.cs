using ManageInformation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Infrastructure.Interfaces
{
    public interface PfrInterface
    {
        ICollection<PFR> GetPFRs();
        PFR GetPFRsById(int id);
        PFR GetPFRsBySNILS(int snils);
        bool CreatePFR(PFR pfr);
        bool UpdatePFR(PFR pfr);
        bool DeletePFR(PFR pfr);
        bool PFRExists(int id);
        bool Save();
    }
}
