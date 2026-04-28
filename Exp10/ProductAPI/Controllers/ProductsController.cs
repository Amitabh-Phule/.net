using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApiDbContext _context;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMemoryCache _cache;

        public ProductsController(ApiDbContext context, ILogger<ProductsController> logger, IMemoryCache cache) 
        { 
            _context = context; 
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("API Request: Fetching product list.");

            if (_cache.TryGetValue("product_list", out List<Product> cachedProducts))
            {
                _logger.LogInformation("Performance Boost: Returning data from Cache.");
                return Ok(cachedProducts);
            }

            _logger.LogWarning("Cache Miss: Querying SQLite Database.");
            var products = _context.Products.ToList();
            
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(System.TimeSpan.FromSeconds(30));
                
            _cache.Set("product_list", products, cacheOptions);

            return Ok(products);
        }

        [HttpPost]
        public IActionResult Post(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            _cache.Remove("product_list");
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
