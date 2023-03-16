using API_Sukha.IServices;
using Entities.Entities;
using Entities.SearchFilters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace APIService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private ISecurityServices _securityServices;
        private IProductServices _productServices;
        public ProductController(ISecurityServices securityServices, IProductServices productServices)
        {
            _securityServices = securityServices;
            _productServices = productServices;
        }

        [HttpPost(Name = "InsertarProducto")]
        public int Post([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] ProductItem productItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _productServices.InsertProduct(productItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "VerProductos")]
        public List<ProductItem> GetAllProducts([FromHeader] string userUsuario, [FromHeader] string userPassword)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _productServices.GetAllProducts();
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpGet(Name = "MostrarProductosPorFiltro")]
        public List<ProductItem> GetProductsByCriteria([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] ProductFilter productFilter)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _productServices.GetProductsByCriteria(productFilter);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }
        [HttpGet(Name = "MostrarProductosPorMarca")]
        public List<ProductItem> GetProductsByMarca([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] string marca)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                return _productServices.GetProductsByMarca(marca);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpPatch(Name = "ModificarProducto")]
        public void Patch([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromBody] ProductItem productItem)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _productServices.UpdateProduct(productItem);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

        [HttpDelete(Name = "EliminarProducto")]
        public void Delete([FromHeader] string userUsuario, [FromHeader] string userPassword, [FromQuery] int id)
        {
            var validCredentials = _securityServices.ValidateUserCredentials(userUsuario, userPassword, 1);
            if (validCredentials == true)
            {
                _productServices.DeleteProduct(id);
            }
            else
            {
                throw new InvalidCredentialException();
            }
        }

    }

}