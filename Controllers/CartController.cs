using CartService.Models;
using CartService.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CartService.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(CartController));
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        // GET api/<TransactionDetailsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _log4net.Info("Get orderDetails by Id accessed");
                var order = _cartRepository.GetById(id);
                return Ok(order);

            }
            catch
            {
                _log4net.Error("Error in Getting order Details");
                return new NoContentResult();
            }
        }

        // POST api/<TransactionDetailsController>
        [HttpPost]
        public IActionResult Post([FromBody] Cart cartobj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("Order Details Getting Added");
                    var _order = _cartRepository.PlaceOrder(cartobj);
                    return CreatedAtAction(nameof(Post), new { id = cartobj.CartId }, cartobj);
                }
                return BadRequest();
            }
            catch
            {
                _log4net.Error("Error in Adding order Details");
                return new NoContentResult();
            }
        }
    }
}
