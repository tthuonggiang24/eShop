using eShop.CoreBussiness.Models;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using eShop.UseCases.ShoppingCartScreen.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateStore shoppingCarStateStore;

        public DeleteProductUseCase(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            this.shoppingCart = shoppingCart;
            this.shoppingCarStateStore = shoppingCartStateStore;
        }
        public async Task<Order> Execute(int productId)
        {
            var order = await this.shoppingCart.DeleteProductAsync(productId);
            this.shoppingCarStateStore.UpdateLineItemsCount();
            return order;
        }
    }
}
