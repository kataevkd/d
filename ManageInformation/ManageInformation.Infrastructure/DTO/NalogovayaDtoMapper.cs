using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageInformation.Domain.Model;

namespace ManageInformation.Infrastructure.DTO
{
    public class NalogovayaDtoMapper
    {
        public static NalogovayaDto ToDto(Nalogovaya nalogovaya)
        {
            var nalogovayaDto = new NalogovayaDto
            {
              INN =  nalogovaya.INN,
              bills = nalogovaya.bills,
              property = nalogovaya.property  
            };

            return nalogovayaDto;
        }
        public static Nalogovaya ToNalogovaya(NalogovayaDto nalogovayaDto)
        {
            var nalogovaya = new Nalogovaya
            {
                INN = nalogovayaDto.INN,
                bills  = nalogovayaDto.bills,
                property = nalogovayaDto.property
            };

            return nalogovaya;
        }
        public static ICollection<NalogovayaDto> ToDtoList(ICollection<Nalogovaya> nalogovayas)
        {
            var NalogovayaDto = new List<NalogovayaDto>();
            foreach (var nalogovaya in nalogovayas)
            {
                NalogovayaDto.Add(ToDto(nalogovaya));
            }
            return NalogovayaDto;
        }
    }
}
