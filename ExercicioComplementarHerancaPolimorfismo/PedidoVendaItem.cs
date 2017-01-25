namespace ExercicioComplementarHerancaPolimorfismo
{
    public class PedidoVendaItem
    {
        public PedidoVenda PedidoVenda { get; private set; }
        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public decimal ValorTotal { get { return Quantidade * ValorUnitario; } }

        public PedidoVendaItem(PedidoVenda pedidoVenda, int quantidade, Produto produto)
        {
            PedidoVenda = pedidoVenda;
            Quantidade = quantidade;
            Produto = produto;
            ValorUnitario = produto.PrecoVenda;
        }
    }
}
