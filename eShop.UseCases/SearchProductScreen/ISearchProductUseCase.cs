using eShop.CoreBussiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.SearchProductScreen
{
    public interface ISearchProductUseCase
    {
        IEnumerable<Product> Execute(string filter = null); //trả về danh sách sản phẩm theo filter

    }
}
