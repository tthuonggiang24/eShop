using eShop.CoreBussiness.Models;

namespace eShop.UseCases.ShoppingCartScreen.interfaces
{
    public interface IViewShoppingCartUseCase
    {
        Task<Order> Execute();
    }
}