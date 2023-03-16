using Data;
using Entities.Entities;
using Entities.SearchFilters;
using Logic.ILogic;

namespace Logic.Logic
{
    public class ProductLogic : IProductLogic
    {
        private readonly ServiceContext _serviceContext;
        public ProductLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public int InsertProduct(ProductItem productItem)
        {
            _serviceContext.Products.Add(productItem);
            _serviceContext.SaveChanges();
            return productItem.Id;
        }

        public void UpdateProduct(ProductItem productItem)
        {
            _serviceContext.Products.Update(productItem);

            _serviceContext.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = _serviceContext.Set<ProductItem>()
                 .Where(u => u.Id == id).First();

            productToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public void DeleteProductMarca(string marca)
        {
            var productMarcaToDelete = _serviceContext.Set<ProductItem>()
                 .Where(u => u.Marca == marca).First();

            productMarcaToDelete.IsActive = false;

            _serviceContext.SaveChanges();

        }

        public List<ProductItem> GetAllProducts()
        {
            return _serviceContext.Set<ProductItem>().ToList();
        }

        public List<ProductItem> GetProductsByCriteria(ProductFilter productFilter)
        {
            var resultList = _serviceContext.Set<ProductItem>()
                                        .Where(u => u.IsActive == true);

            //.Where(u => u.Marca = productFilter.Marca);

            if (productFilter.InsertDateFrom != null)
            {
                resultList = resultList.Where(u => u.InsertDate > productFilter.InsertDateFrom);
            }

            if (productFilter.InsertDateTo != null)
            {
                resultList = resultList.Where(u => u.InsertDate < productFilter.InsertDateTo);
            }
            if (productFilter.PrecioDesde != null)
            {
                resultList = resultList.Where(u => u.Precio > productFilter.PrecioDesde);
            }

            if (productFilter.PrecioHasta != null)
            {
                resultList = resultList.Where(u => u.Precio < productFilter.PrecioHasta);
            }

            return resultList.ToList();
        }

        public List<ProductItem> GetProductsByMarca(string marca)
        {
            var resultList = _serviceContext.Set<ProductItem>()
                        .Where(p => p.Marca == marca);
            return resultList.ToList();
        }



    }
}

