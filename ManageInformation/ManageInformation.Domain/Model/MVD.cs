using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageInformation.Domain.Model
{
    public class MVD
    {
        public int Id { get; set; }
        public int Passport { get; set; }
        public string FamilyName { get; set;} = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string FatherName { get; set; } = String.Empty;
        public DateTime Date { get; set;}
        public string Address { get; set; } = String.Empty;

    }
}
