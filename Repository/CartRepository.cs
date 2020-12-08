using CartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Repository
{
    public class CartRepository : ICartRepository
    {
        public static List<Cart> order = new List<Cart>();
        public IEnumerable<Cart> GetById(int userid)
        {
            return order.Where(b => b.UserId == userid).ToList<Cart>();
        }

        public Cart PlaceOrder(Cart cartobj)
        {
            order.Add(cartobj);
            return cartobj;
        }
    }
}
