using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterfaces.StateStore
{
    public interface IShoppingCartStateStore : IStateStore
    {
        //Lấy số biến của các item trong giỏ hàng
        Task<int> GetItemCount();
        void UpdateLineItemsCount();
        void UpdateProductQuantity();
    }
}
