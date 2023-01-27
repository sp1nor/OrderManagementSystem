using Catalog.API.Entities;

namespace Catalog.API.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Product item)
        {
            _context.Add(item);
            Save();
        }

        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            _context.Products.Remove(product);
            Save();
        }

        public void Delete(Product item)
        {
            _context.Products.Remove(item);
            Save();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetItemById(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            return product;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product item)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == item.Id);
            product.Name = item.Name;
            product.Price = item.Price;
            Save();
        }
    }
}
