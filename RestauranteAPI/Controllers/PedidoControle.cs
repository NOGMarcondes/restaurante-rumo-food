using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.Data;
using RestauranteAPI.Models;

namespace RestauranteAPI.Controllers
{

    [ApiController]
    [Route("api/pedidos")]
    public class PedidoControle : ControllerBase
    {

        private readonly AppDbContext _context;

        public PedidoControle(AppDbContext context) {

            _context = context;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var pedidos = _context.Pedidos.ToList();
            return Ok(pedidos);
        }

        [HttpGet]
        [Route ("cozinha")]
        public IActionResult GetCozinha()
        {
            var pedidos = _context.Pedidos
            .Where(p  => p.SetorPedido == "Cozinha").ToList();
            return Ok(pedidos);
        }

        [HttpGet]
        [Route("copa")]

        public IActionResult GetCopa()
        {
            var pedidos = _context.Pedidos
            .Where(p => p.SetorPedido == "Copa")
            .ToList();
            return Ok(pedidos);
        }

        [HttpPost]

        public IActionResult Crate(Pedido pedido) {

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return Ok(pedido);
        
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarStatus(int id, [FromQuery] string status)
        {
            var pedido = _context.Pedidos
                .FirstOrDefault(p => p.Id == id);

            if (pedido == null)
                return NotFound();

            pedido.StatusPedido = status;
            _context.SaveChanges();
            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _context.Pedidos
                .FirstOrDefault(p => p.Id == id);

            if (pedido == null)
                return NotFound();

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
            return Ok();
        }
    }
}