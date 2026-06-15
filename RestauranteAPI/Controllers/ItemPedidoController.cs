using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Data;
using RestauranteAPI.Models;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("api/itempedido")]


    public class ItemPedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemPedidoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(ItemPedido itemPedido)
        {
            _context.ItemPedidos.Add(itemPedido);
            _context.SaveChanges();
            return Ok(itemPedido);
        }

        [HttpGet("{pedidoId}")]

        public IActionResult GetByPedido(int pedidoId)
        {
            var ItemPedidos = _context.ItemPedidos.Where(i => i.PedidoId == pedidoId).ToList();

            return Ok(ItemPedidos);


        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.ItemPedidos
                .FirstOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            _context.ItemPedidos.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
    }


}