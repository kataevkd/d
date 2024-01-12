using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageInformation.Domain.Model;
using ManageInformation.Infrastructure.Data;
using ManageInformation.Infrastructure.Interfaces;

namespace ManageInformation.Infrastructure.Repos
{
    public class MvdRepo:MvdInterface
    {
        private readonly Context _context;
        public MvdRepo(Context context)
        {
            _context = context;
        }

        public bool CreateMvd(MVD mvd)
        {
            _context.Add(mvd); 
            return Save();
        }

        public bool DeleteMvd(MVD mvd)
        {
            _context.Remove(mvd);
            return Save();
        }

        public ICollection<MVD> GetMVDs()
        {
            return _context.mvd.OrderBy(x => x.Id).ToList();
        }

        public MVD GetMVDsById(int id)
        {
            return _context.mvd.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<MVD> GetMVDsByName(string name)
        {
            return _context.mvd.Where(x => x.Name == name).ToList();
        }

        public bool MvdExists(int id)
        {
            return _context.mvd.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateMvd(MVD mvd)
        {
            _context.Update(mvd);
            return Save();
        }

        public Person GetPersonByPassport(int passport)
        {
            return _context.person.Where(x=> x.MVDId == _context.mvd.Where(p=> p.Passport == passport).FirstOrDefault().Id).FirstOrDefault();
        }
        public MVD GetMVDByPassport(int passport)
        {
            return _context.mvd.Where(x=> x.Passport == passport).FirstOrDefault();
        }
    }
}
