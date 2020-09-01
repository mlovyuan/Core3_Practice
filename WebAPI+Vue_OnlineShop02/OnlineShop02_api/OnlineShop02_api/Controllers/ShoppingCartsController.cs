using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop02_api.Entities;
using OnlineShop02_api.Models.ShoppingCartsDto;

namespace OnlineShop02_api.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly OnlineShopApiContext _context;

        public ShoppingCartsController(OnlineShopApiContext context)
        {
            _context = context;
        }

        // GET: api/ShoppingCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingCarts>>> GetShoppingCarts()
        {
            // 獲取ShoppingCarts及前者於Product table Fk相對應的資料
            return await _context.ShoppingCarts.Include((x) => x.Product).ToArrayAsync();
        }

        // GET: api/ShoppingCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingCarts>> GetShoppingCarts(int id)
        {
            var shoppingCarts = await _context.ShoppingCarts.FindAsync(id);

            if (shoppingCarts == null)
            {
                return NotFound();
            }

            return shoppingCarts;
        }

        // PUT: api/ShoppingCarts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingCarts(int id, ShoppingCarts shoppingCarts)
        {
            if (id != shoppingCarts.Id)
            {
                return BadRequest();
            }

            _context.Entry(shoppingCarts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ShoppingCarts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ShoppingCarts>> PostShoppingCarts(AddCartInput input)
        {
            ShoppingCarts shoppingCarts = new ShoppingCarts()
            {
                Count = input.Count,
                Size = input.Size,
                ProductId = input.ProductId
            };
            _context.ShoppingCarts.Add(shoppingCarts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShoppingCarts", new { id = shoppingCarts.Id }, shoppingCarts);
        }

        // DELETE: api/ShoppingCarts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShoppingCarts>> DeleteShoppingCarts(int id)
        {
            var shoppingCarts = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCarts == null)
            {
                return NotFound();
            }

            _context.ShoppingCarts.Remove(shoppingCarts);
            await _context.SaveChangesAsync();

            return shoppingCarts;
        }

        private bool ShoppingCartsExists(int id)
        {
            return _context.ShoppingCarts.Any(e => e.Id == id);
        }
    }
}
