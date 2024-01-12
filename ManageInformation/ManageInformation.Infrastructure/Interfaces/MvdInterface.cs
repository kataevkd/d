using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageInformation.Domain.Model;

namespace ManageInformation.Infrastructure.Interfaces
{
    public interface MvdInterface
    {
        ICollection<MVD> GetMVDs();
        ICollection<MVD> GetMVDsByName(string name);
        Person GetPersonByPassport(int passport);
        MVD GetMVDsById(int id);
        MVD GetMVDByPassport(int passport);

        bool CreateMvd(MVD mvd);
        bool UpdateMvd(MVD mvd);
        bool DeleteMvd(MVD mvd);
        bool MvdExists(int id);
        bool Save();

    }
}
