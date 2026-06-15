using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Data;
using RestauranteAPI.Models;

namespace RestauranteAPI.Controllers
{

    [ApiController]
    [Route("api/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult getAll()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpPost]
        public IActionResult Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos
                .FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound();

            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return Ok();
        }
    }
}
