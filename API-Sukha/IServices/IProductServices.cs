using Entities.Entities;
using Entities.SearchFilters;

namespace API_Sukha.IServices
{
    public interface IProductServices
    {
        int InsertProduct(ProductItem productItem);
        void UpdateProduct(ProductItem productItem);
        void DeleteProduct(int id);
        List<ProductItem> GetAllProducts();
        List<ProductItem> GetProductsByCriteria(ProductFilter productFilter);
        List<ProductItem> GetProductsByMarca(string marca);
    }
}
