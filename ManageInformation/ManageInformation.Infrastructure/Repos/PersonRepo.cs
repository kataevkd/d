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
    public class PersonRepo : PersonInterface
    {
        private readonly Context _context;
        public PersonRepo(Context context)
        {
            _context = context;
        }

        public bool CreatePerson(Person person)
        {
           /* person.PFR = _context.pfr.Where(x=> x.Id == person.PFRId).FirstOrDefault();
            person.MVD = _context.mvd.Where(x=> x.Id == person.MVDId).FirstOrDefault();
            person.GIBDD = _context.gibdd.Where(x=> x.Id == person.GIBDDId).FirstOrDefault();
            person.Nalogovaya = _context.nalogi.Where(x=> x.Id == person.NalogovayaId).FirstOrDefault();*/
            _context.Add(person);
            return Save();
        }

        public bool DeletePerson(Person person)
        {
            _context.Remove(person);
            return Save();
        }

        public ICollection<Person> GetPersons()
        {
            return _context.person.OrderBy(x => x.Id).ToList();
        }

        public Person GetPersonsById(int id)
        {
            return _context.person.Where(x => x.Id == id).First();
        }

        public bool PersonExists(int id)
        {
            return _context.person.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePerson(Person person)
        {
            _context.Update(person);
            return Save();
        }

        public MVD GetPersonsMVD(int idformvd)
        {
            return _context.mvd.Where(x=>x.Id == _context.person.Where(q=>q.Id==idformvd).First().MVDId).First();
        }
        public PFR GetPersonsPFR(int idformvd)
        {
            return _context.pfr.Where(x => x.Id == _context.person.Where(q => q.Id == idformvd).First().PFRId).First();
        }
        public Nalogovaya GetPersonsNalogovaya(int idformvd)
        {
            return _context.nalogi.Where(x => x.Id == _context.person.Where(q => q.Id == idformvd).First().NalogovayaId).First();
        }
        public GIBDD GetPersonsGIBDD(int idformvd)
        {
            return _context.gibdd.Where(x => x.Id == _context.person.Where(q => q.Id == idformvd).First().GIBDDId).First();
        }
    }
}
