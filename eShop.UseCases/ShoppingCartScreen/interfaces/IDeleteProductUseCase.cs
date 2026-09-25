using eShop.CoreBussiness.Models;

namespace eShop.UseCases.ShoppingCartScreen.interfaces
{
    public interface IDeleteProductUseCase
    {
        Task<Order> Execute(int productId);
    }
}