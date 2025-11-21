using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHeroBannerServices
    {
        Task<IEnumerable<HeroBannerDTo>> GetAllHeroBanner();
        Task<HeroBannerDTo?> GetMetaPageById(int id);
        Task<bool> AddNewHeroBanner(HeroBannerDTo createHeroBannerDTo);
        Task<bool> UpdateHeroBanner(HeroBannerDTo createHeroBannerDTo);
    }
}
