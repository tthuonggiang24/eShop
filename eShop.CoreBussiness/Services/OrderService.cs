using eShop.CoreBussiness.Models;
using eShop.CoreBussiness.Services.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.CoreBussiness.Services
{
    public class OrderService : IOrderService
    {
        public bool ValidateCustomerInfomation(string name, string address, string city, string province, string country)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(province) ||
                string.IsNullOrWhiteSpace(country))
            {
                return false;
            }
            return true;
        }
        public bool ValidateCreateOrder(Order order)
        {
            //Phai ton tai 1 order    
            if (order == null)
                return false;
            //order it nhat phai co 1 line item
            if (order.LineItems == null || order.LineItems.Count <= 0)
                return false;
            //validate line item
            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 ||
                    item.Quantity <= 0 ||
                    item.Price < 0)
                    return false;
            }
            //validate customer information
            if (!ValidateCustomerInfomation(order.CustomerName,
                order.CustomerAddress,
                order.CustomerCity,
                order.CustomerStateProvince,
                order.CustomerCountry))
                return false;
            return true;
        }
        public bool ValidateUpdateOrder(Order order)
        {
            //Phai ton tai 1 order    
            if (order == null) return false;
            if (!order.OrderId.HasValue) return false;
            //order it nhat phai co 1 line item
            if (order.LineItems == null || order.LineItems.Count <= 0)
                return false;
            //Placed date has to be populated
            if (!order.DatePlaced.HasValue) return false;
            //Other dates
            if (order.DateProcessed.HasValue || order.DateProcessing.HasValue) return false;
            //Validate unique id
            if (string.IsNullOrWhiteSpace(order.UniqueId)) return false;
            //validate line item
            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 ||
                    item.Quantity <= 0 ||
                    item.Price < 0 ||
                    item.OrderId == order.OrderId)
                    return false;
            }
            //validate customer information
            if (!ValidateCustomerInfomation(order.CustomerName,
                order.CustomerAddress,
                order.CustomerCity,
                order.CustomerStateProvince,
                order.CustomerCountry))
                return false;
            return true;
        }
        public bool ValidateProcessOrder(Order order)
        {
            //Ngay da xu ly xong, co gia tri
            if (!order.DateProcessed.HasValue ||
                string.IsNullOrWhiteSpace(order.AdminUser))
                return false;
            return true;
        }
    }
}
