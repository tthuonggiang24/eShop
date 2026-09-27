using eShop.CoreBussiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.AdminPortal.OutstandingOrdersScreen
{
    public class ViewOutstandingOrdersUseCase : IViewOutstandingOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;
        public ViewOutstandingOrdersUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public IEnumerable<Order> Execute()
        {
            return orderRepository.GetOutStandingOrders();
        }
    }
}
