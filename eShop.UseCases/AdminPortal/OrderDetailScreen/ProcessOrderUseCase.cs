using eShop.CoreBussiness.Services.@interface;
using eShop.UseCases.AdminPortal.OrderDetailScreen.Interfaces;
using eShop.UseCases.PluginInterfaces.DataStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.AdminPortal.OrderDetailScreen
{
    public class ProcessOrderUseCase : IProcessOrderUseCase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderService orderService;
        public ProcessOrderUseCase(IOrderRepository orderRepository, IOrderService orderService)
        {
            this.orderRepository = orderRepository;
            this.orderService = orderService;
        }
        public bool Execute(int orderId, string adminUserName)
        {
            var order = orderRepository.GetOrder(orderId);
            order.AdminUser = adminUserName;
            order.DateProcessed = DateTime.Now;
            if (orderService.ValidateProcessOrder(order))
            {
                orderRepository.UpdateOrder(order);
                return true;
            }
            return false;
        }
    }
}
