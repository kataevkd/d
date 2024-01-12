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
    public class PfrRepo : PfrInterface
    {
        private readonly Context _context;
        public PfrRepo(Context context)
        {
            _context = context;
        }

        public bool CreatePFR(PFR pfr)
        {
            _context.Add(pfr);
            return Save();
        }

        public bool DeletePFR(PFR pfr)
        {
            _context.Remove(pfr);
            return Save();
        }

        public ICollection<PFR> GetPFRs()
        {
            return _context.pfr.OrderBy(x => x.Id).ToList();
        }

        public PFR GetPFRsById(int id)
        {
            return _context.pfr.Where(x => x.Id == id).FirstOrDefault();
        }

        public PFR GetPFRsBySNILS(int snils)
        {
            return _context.pfr.Where(x => x.SNILS == snils).FirstOrDefault();
        }


        public bool PFRExists(int id)
        {
            return _context.pfr.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePFR(PFR pfr)
        {
            _context.Update(pfr);
            return Save();
        }
    }
}
