using eShop.CoreBussiness.Models;

namespace eShop.UseCases.ShoppingCartScreen.interfaces
{
    public interface IUpdateQuantityUseCase
    {
        Task<Order> Execute(int productId, int quantity);
    }
}