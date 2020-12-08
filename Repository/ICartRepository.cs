using CartService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Repository
{
    public interface ICartRepository
    {
        public IEnumerable<Cart> GetById(int userid);
        Cart PlaceOrder(Cart cartobj);
    }
}
