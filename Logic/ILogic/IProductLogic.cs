using Entities.Entities;
using Entities.SearchFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IProductLogic
    {
        int InsertProduct(ProductItem productItem);
        void UpdateProduct(ProductItem productItem);
        void DeleteProduct(int id);
        void DeleteProductMarca(string marca);
        List<ProductItem> GetAllProducts();
        List<ProductItem> GetProductsByCriteria(ProductFilter productFilter);
        List<ProductItem> GetProductsByMarca(string marca);
    }
}
