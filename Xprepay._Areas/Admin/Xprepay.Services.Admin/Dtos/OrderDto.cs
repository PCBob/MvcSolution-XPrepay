using System.Linq;
using AutoMapper;
using Xprepay.Services.Dtos;
using Xprepay.Services.Admin.Dtos;
using Xprepay.Data.Entities;
using System;
using System.Collections.Generic;
using Xprepay.Data;

namespace Xprepay.Services.Admin.Dtos
{
    public class OrderDto: DtoBase
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
        public List<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }
}

namespace Xprepay
{
    public static class OrderDtoExtAdmin
    {
        public static IQueryable<OrderDto> ToDtos(this IQueryable<Order> query)
        {
            return from a in query
                   select new OrderDto()
                   {
                       BuyerName=a.BuyerName,
                       BuyId=a.BuyId,
                       CreatedTime=a.CreatedTime,
                       Delflag=a.Delflag,
                       DeliveryAddress=a.DeliveryAddress,
                       DeliveryTime=a.DeliveryTime,
                       Id=a.Id,
                       LastUpdatedTime=a.LastUpdatedTime,
                       Money=a.Money,
                       OrderNum=a.OrderNum,
                       OrderTime=a.OrderTime,
                       PhoneNum=a.PhoneNum,
                       Remark=a.Remark
                   };
        }
        public static OrderDto ToDto(this Order entity)
        {
            if (entity!=null)
            {
                return Mapper.Map<OrderDto>(entity);
            }
            return new OrderDto();
        }
    }
}

