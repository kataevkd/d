using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageInformation.Domain.Model;

namespace ManageInformation.Infrastructure.DTO
{
    public class PfrDtoMapper
    {
        public static PfrDto ToDto(PFR pfr)
        {
            var pfrDto = new PfrDto
            {
                SNILS = pfr.SNILS,
                WorkBook = pfr.WorkBook,
                SocialStatus = pfr.SocialStatus
            };

            return pfrDto;
        }
        public static PFR ToPFR(PfrDto pfrDto)
        {
            var pfr = new PFR
            {
                //Id = pfrDto.Id,
                SNILS = pfrDto.SNILS,
                WorkBook = pfrDto.WorkBook,
                SocialStatus = pfrDto.SocialStatus
            };

            return pfr;
        }
        public static ICollection<PfrDto> ToDtoList(ICollection<PFR> pfrs)
        {
            var PfrDto = new List<PfrDto>();
            foreach (var pfr in pfrs)
            {
                PfrDto.Add(ToDto(pfr));
            }
            return PfrDto;
        }
    }
}
