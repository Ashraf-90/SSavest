using Application.DTOs;
using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public class HeroBannerServices : IHeroBannerServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public HeroBannerServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<bool> AddNewHeroBanner(HeroBannerDTo createHeroBannerDTo)
        {
            var data = mapper.Map<HeroBanner>(createHeroBannerDTo);
            var result = await unitOfWork.HeroBanner.AddAsync(data);
            await unitOfWork.SaveChangesAsync();
            return result;
        }

        public async Task<bool> UpdateHeroBanner(HeroBannerDTo updateHeroBannerDTo)
        {
            var HeroBanner = await unitOfWork.HeroBanner.GetAllAsyncWitFillter(
                new List<Expression<Func<HeroBanner, bool>>> { x => x.Id == updateHeroBannerDTo.Id });

            var entity = HeroBanner.FirstOrDefault();
            if (entity == null) return false;

            mapper.Map(updateHeroBannerDTo, entity); // AutoMapper updates fields
            var result = await unitOfWork.HeroBanner.UpdateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return result;
        }


        public async Task<IEnumerable<HeroBannerDTo>> GetAllHeroBanner()
        {
            var data = await unitOfWork.HeroBanner.GetAllAsync();
            var result = mapper.Map<IEnumerable<HeroBannerDTo>>(data);

            return result;
        }


        public async Task<HeroBannerDTo?> GetMetaPageById(int id)
        {
            var HeroBanner = await unitOfWork.HeroBanner.GetAllFillterIncludeData(filters: new List<Expression<Func<HeroBanner, bool>>> { x => x.Id == id });
            var entity = HeroBanner.FirstOrDefault();
            return entity == null ? null : mapper.Map<HeroBannerDTo>(entity);
        }
    }
}
