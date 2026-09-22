using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.CoreBussiness.Models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.UseCases.SearchProductScreen
{
    public class SearchProductUseCase : ISearchProductUseCase
    {
        private readonly IProductRepository productReponsitory;
        public SearchProductUseCase(IProductRepository productReponsitory) 
        { 
            this.productReponsitory = productReponsitory;
        }

        public IEnumerable<Product> Execute(string filter)
        {
            return productReponsitory.GetProducts(filter); //trả về danh sách sản phẩm
        }
    }
}
