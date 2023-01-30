using WebMVC.Model;

namespace WebMVC.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<ProductModel>> GetCatalog();
    }
}
