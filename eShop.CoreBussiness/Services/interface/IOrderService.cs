using eShop.CoreBussiness.Models;

namespace eShop.CoreBussiness.Services.@interface
{
    public interface IOrderService
    {
        bool ValidateCreateOrder(Order order);
        bool ValidateCustomerInfomation(string name, string address, string city, string province, string country);
        bool ValidateProcessOrder(Order order);
        bool ValidateUpdateOrder(Order order);
    }
}