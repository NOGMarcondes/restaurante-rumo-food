namespace RestauranteAPI.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int numMesa { get; set; }

        public string NomeCliente { get; set; }

        public string StatusPedido { get; set; }

        public DateTime DataPedido { get; set; }

        public int UsuarioId { get; set; }

        public string SetorPedido {  get; set; }
    }
}
