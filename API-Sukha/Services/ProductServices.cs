using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;
using Logic.Logic;

public class ProductServices : IProductServices
{
    private readonly IProductLogic _productLogic;
    public ProductServices(IProductLogic productLogic)
    {
        _productLogic = productLogic;
    }
    public int InsertProduct(ProductItem productItem)
    {
        _productLogic.InsertProduct(productItem);
        return productItem.Id;
    }
    public List<ProductItem> GetAllProducts()
    {
        return _productLogic.GetAllProducts();
    }
    public List<ProductItem> GetProductsByCriteria(ProductFilter productFilter)
    {
        return _productLogic.GetProductsByCriteria(productFilter);
    }

    public List<ProductItem> GetProductsByMarca(string marca)
    {
        return _productLogic.GetProductsByMarca(marca);
    }

    public void UpdateProduct(ProductItem productItem)
    {
        _productLogic.UpdateProduct(productItem);
    }

    public void DeleteProduct(int id)
    {
        _productLogic.DeleteProduct(id);
    }

}

