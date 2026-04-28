using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public ProductsController(ApiDbContext context) { _context = context; }

        [HttpGet]
        public List<Product> Get() => _context.Products.ToList();

        [HttpPost]
        public IActionResult Post(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return Ok(p);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Product p)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            
            product.Name = p.Name;
            product.Price = p.Price;
            _context.SaveChanges();
            return Ok(product);
        }
    }
}
