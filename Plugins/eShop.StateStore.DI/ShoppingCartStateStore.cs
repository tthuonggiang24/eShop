using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.StateStore.DI
{
    public class ShoppingCartStateStore : StateStoreBase, IShoppingCartStateStore
    {
        private readonly IShoppingCart shoppingCart;
        public ShoppingCartStateStore(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }
        public async Task<int> GetItemCount()
        {
            var orders = await shoppingCart.GetOrderAsync();
            if(orders != null && orders.LineItems != null && orders.LineItems.Count > 0)
                return orders.LineItems.Count;
            return 0;
        }

        public void UpdateLineItemsCount()
        {
            base.BroadcastStateChange();
        }
    }
}
