using Basket.API.Entities;

namespace Basket.API.Persistence.Repositories
{
    public interface IBasketRepository
    {
        Task<Cart> GetBasket(string userName);
        Task<Cart> UpdateBasket(Cart basket);
        Task DeleteBasket(string userName);
    }
}
