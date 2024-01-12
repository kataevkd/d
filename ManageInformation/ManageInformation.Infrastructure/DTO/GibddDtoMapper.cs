using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManageInformation.Domain.Model;

namespace ManageInformation.Infrastructure.DTO
{
    public class GibddDtoMapper
    {
        public static GibddDto ToDto(GIBDD gibdd)
        {
            var gibddDto = new GibddDto
            {
                Category = gibdd.Category,
                License = gibdd.License
            };

            return gibddDto;
        }
        public static GIBDD ToGIBDD(GibddDto gibddDto)
        {
            var gibdd = new GIBDD
            {
                Category = gibddDto.Category,
                License = gibddDto.License
            };

            return gibdd;
        }
        public static ICollection<GibddDto> ToDtoList(ICollection<GIBDD> gibdds)
        {
            var GibddDto = new List<GibddDto>();
            foreach (var gibdd in gibdds)
            {
                GibddDto.Add(ToDto(gibdd));
            }
            return GibddDto;
        }
    }
}
