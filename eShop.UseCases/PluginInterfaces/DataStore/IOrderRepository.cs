using eShop.CoreBussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterfaces.DataStore
{
    public interface IOrderRepository
    {
        Order GetOrder(int id);
        Order GetOrderByUniqueId(string uniqueId);
        int CreateOrder(Order order);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetOrders();
        IEnumerable<Order> GetOutStandingOrders();
        IEnumerable<Order> GetProcessedOrders();
        IEnumerable<Order> GetLineItemsByOrderId(int orderId);
    }
}
