using ManageInformation.Domain.Model;
using ManageInformation.Infrastructure.Data;
using ManageInformation.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Infrastructure.Repos
{
    public class GibddRepo : GibddInterface
    {
        private readonly Context _context;
        public GibddRepo(Context context)
        {
            _context = context;
        }

        public bool CreateGIBDD(GIBDD gibdd)
        {
            _context.Add(gibdd);
            return Save();
        }

        public bool DeleteGIBDD(GIBDD gibdd)
        {
            _context.Remove(gibdd);
            return Save();
        }

        public ICollection<GIBDD> GetGIBDDs()
        {
            return _context.gibdd.OrderBy(x => x.Id).ToList();
        }

        public GIBDD GetGIBDDsById(int id)
        {
            return _context.gibdd.Where(x => x.Id == id).FirstOrDefault();
        }
        public GIBDD GetGIBDDsByLicense(int license)
        {
            return _context.gibdd.Where(x => x.License == license).FirstOrDefault();
        }

        public bool GIBDDExists(int id)
        {
            return _context.gibdd.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateGIBDD(GIBDD gibdd)
        {
            _context.Update(gibdd);
            return Save();
        }
    }
}
