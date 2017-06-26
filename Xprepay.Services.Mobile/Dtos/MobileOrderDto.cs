using System.Linq;
using AutoMapper;
using Xprepay.Services.Dtos;
using Xprepay.Services.Mobile.Dtos;
using Xprepay.Data.Entities;
using System;
using System.Collections.Generic;

namespace Xprepay.Services.Mobile.Dtos
{
    public class MobileOrderDto: DtoBase
    {
        /// <summary>
        /// ������
        /// </summary>
        public string OrderNum { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public decimal? Money { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// ������
        /// </summary>
        public Guid BuyId { get; set; }
        /// <summary>
        /// ����������
        /// </summary>
        public string BuyerName { get; set; }
        /// <summary>
        /// ��ַ
        /// </summary>
        public Guid AddressId { get; set; }
        /// <summary>
        /// ���͵�ַ
        /// </summary>
        public virtual Address Address { get; set; }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// �ֻ���
        /// </summary>
        public string PhoneNum { get; set; }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? DeliveryTime { get; set; }
        /// <summary>
        /// �µ�ʱ��
        /// </summary>
        public DateTime? OrderTime { get; set; }
    }
}

namespace Xprepay
{
    public static class MobileOrderDtoExtAdmin
    {
        public static IQueryable<MobileOrderDto> ToDtos(this IQueryable<Order> query)
        {
            return from a in query
                   select new MobileOrderDto()
                   {
                       BuyerName = a.BuyerName,
                       BuyId = a.BuyId,
                       CreatedTime = a.CreatedTime,
                       Delflag = a.Delflag,
                       DeliveryAddress = a.DeliveryAddress,
                       DeliveryTime = a.DeliveryTime,
                       Id = a.Id,
                       LastUpdatedTime = a.LastUpdatedTime,
                       Money = a.Money,
                       OrderNum = a.OrderNum,
                       OrderTime = a.OrderTime,
                       PhoneNum = a.PhoneNum,
                       Remark = a.Remark
                   };
        }
        public static MobileOrderDto ToDto(this Order entity)
        {
            if (entity!=null)
            {
                return Mapper.Map<MobileOrderDto>(entity);
            }
            return new MobileOrderDto();
        }
    }
}

