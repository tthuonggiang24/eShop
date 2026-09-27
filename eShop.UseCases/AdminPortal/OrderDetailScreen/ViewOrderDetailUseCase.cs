using eShop.CoreBussiness.Models;
using eShop.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.AdminPortal.OrderDetailScreen
{
    public class ViewOrderDetailUseCase : IViewOrderDetailUseCase
    {
        private readonly IOrderRepository orderRepository;
        public ViewOrderDetailUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public Order Execute(int orderId)
        {
            return orderRepository.GetOrder(orderId);
        }
    }
}
