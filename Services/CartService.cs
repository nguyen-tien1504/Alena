using Alena.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
namespace Alena.Services
{
    public class CartService
    {
        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "cart";
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<CartItemModel> getCart()
        {
            string jsonCart = _session.GetString(CARTKEY);

            if (jsonCart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItemModel>>(jsonCart);
            }

            return new List<CartItemModel>();
        }

        public void clearCart()
        {
            _session.Remove(CARTKEY);
        }

        public void saveCartSession(List<CartItemModel> ls)
        {
            string jsonCart = JsonConvert.SerializeObject(ls);
            _session.SetString(CARTKEY, jsonCart);
        }
    }
}
