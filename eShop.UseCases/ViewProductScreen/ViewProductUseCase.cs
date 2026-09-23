using eShop.CoreBussiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.ViewProductScreen.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.ViewProductScreen
{
    public class ViewProductUseCase : IViewProductUseCase
    {
        private readonly IProductRepository productReponsitory;
        public ViewProductUseCase(IProductRepository productReponsitory)
        {
            this.productReponsitory = productReponsitory;
        }
        public Product Execute(int id)
        {
            return productReponsitory.GetProduct(id);
        }
    }
}
