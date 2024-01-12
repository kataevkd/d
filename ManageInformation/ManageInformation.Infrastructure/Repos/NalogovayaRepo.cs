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
    public class NalogovayaRepo : NalogovayaInterface
    {
        private readonly Context _context;
        public NalogovayaRepo(Context context)
        {
            _context = context;
        }

        public bool CreateNalogovaya(Nalogovaya nalogovaya)
        {
            _context.Add(nalogovaya);
            return Save();
        }

        public bool DeleteNalogovaya(Nalogovaya nalogovaya)
        {
            _context.Remove(nalogovaya);
            return Save();
        }

        public ICollection<Nalogovaya> GetNalogovayas()
        {
            return _context.nalogi.OrderBy(x => x.Id).ToList();
        }

        public Nalogovaya GetNalogovayasById(int id)
        {
            return _context.nalogi.Where(x => x.Id == id).FirstOrDefault();
        }
        public Nalogovaya GetNalogovayasByINN(int inn)
        {
            return _context.nalogi.Where(x => x.INN == inn).FirstOrDefault();
        }

        public bool NalogovayaExists(int id)
        {
            return _context.nalogi.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateNalogovaya(Nalogovaya nalogovaya)
        {
            _context.Update(nalogovaya);
            return Save();
        }
    }
}
