using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageInformation.Domain.Model;

namespace ManageInformation.Infrastructure.DTO
{
    public class MvdDtoMapper
    {
        public static MvdDto ToDto(MVD mvd)
        {
            var mvdDto = new MvdDto
            {
                //Id = mvd.Id,
                Passport = mvd.Passport,
                FamilyName = mvd.FamilyName,
                Name = mvd.Name,
                FatherName = mvd.FatherName,
                Date = mvd.Date,
                Address = mvd.Address
            };

            return mvdDto;
        }
        public static MVD ToMVD(MvdDto mvdDto)
        {
            var mvd = new MVD
            {
                //Id = mvdDto.Id,
                Passport = mvdDto.Passport,
                FamilyName = mvdDto.FamilyName,
                Name = mvdDto.Name,
                FatherName = mvdDto.FatherName,
                Date = mvdDto.Date,
                Address = mvdDto.Address
            };

            return mvd;
        }
        public static ICollection<MvdDto> ToDtoList(ICollection<MVD> mvds)
        {
            var MvdDto = new List<MvdDto>();
            foreach (var mvd in mvds)
            {
                MvdDto.Add(ToDto(mvd));
            }
            return MvdDto;
        }

        public static MVD ToMVDWithId(MvdDtoWithId mvdDto)
        {
            var mvd = new MVD
            {
                Id = mvdDto.Id,
                Passport = mvdDto.Passport,
                FamilyName = mvdDto.FamilyName,
                Name = mvdDto.Name,
                FatherName = mvdDto.FatherName,
                Date = mvdDto.Date,
                Address = mvdDto.Address
            };

            return mvd;
        }
    }
}
