using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioComplementarHerancaPolimorfismo
{
    public class PedidoVenda
    {
        public DateTime DataVenda { get; private set; }
        public Cliente Cliente { get; private set; }
        public decimal ValorBruto { get { return Itens.Sum(i => i.ValorTotal); } }
        public IList<PedidoVendaItem> Itens { get; private set; }
        public decimal ValorLiquido { get; private set; }

        public PedidoVenda(DateTime dataVenda, Cliente cliente)
        {
            DataVenda = dataVenda;
            Cliente = cliente;
            Itens = new List<PedidoVendaItem>();
        }

        public void CalcularValorLiquido(EstrategiaDesconto estrategiaDesconto)
        {
            ValorLiquido = estrategiaDesconto.AplicarDesconto(this);
        }
    }
}
