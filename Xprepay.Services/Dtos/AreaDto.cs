using System.Linq;
using AutoMapper;
using Xprepay.Services.Dtos;
using Xprepay.Data.Entities;
using System;

namespace Xprepay.Services.Dtos
{
    public class AreaDto: DtoBase
    {
        /// <summary>
        /// ��������
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public string AreaCode { get; set; }
        /// <summary>
        /// ���
        /// </summary>
        public Guid? ParentRegionID { get; set; }
    }
}

namespace Xprepay
{
    public static class AreaDtoExtAdmin
    {
        public static IQueryable<AreaDto> ToDtos(this IQueryable<Area> query)
        {
            return from a in query
                   select new AreaDto()
                   {
                       AreaCode = a.AreaCode,
                       CreatedTime = a.CreatedTime,
                       Delflag = a.Delflag,
                       Id = a.Id,
                       LastUpdatedTime = a.LastUpdatedTime,
                       Name = a.Name,
                       ParentRegionID = a.ParentRegionID,
                   };
        }
        public static AreaDto ToDto(this Area entity)
        {
            if (entity!=null)
            {
                return Mapper.Map<AreaDto>(entity);
            }
            return new AreaDto();
        }
    }
}

