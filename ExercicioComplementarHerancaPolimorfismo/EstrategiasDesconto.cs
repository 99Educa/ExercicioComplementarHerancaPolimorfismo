using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioComplementarHerancaPolimorfismo
{
    public abstract class EstrategiaDesconto
    {
        protected PedidoVenda PedidoVenda;

        public decimal AplicarDesconto(PedidoVenda pedidoVenda)
        {
            PedidoVenda = pedidoVenda;
            return (PedidoVenda.ValorBruto * (1 - ObterPercentualDesconto())) - ObterValorDescontoAdicional();
        }

        protected virtual decimal ObterValorDescontoAdicional()
        {
            return 0;
        }

        protected abstract decimal ObterPercentualDesconto();
    }

    public class Inativo : EstrategiaDesconto
    {
        protected override decimal ObterPercentualDesconto()
        {
            return PedidoVenda.ValorBruto > 100m ? .05m : 0;
        }
    }

    public class Novo : EstrategiaDesconto
    {
        protected override decimal ObterPercentualDesconto()
        {
            return 0;
        }

        protected override decimal ObterValorDescontoAdicional()
        {
            return PedidoVenda.ValorBruto > 100m ? 10m : 0;
        }
    }

    public class Recorrente : EstrategiaDesconto
    {
        protected override decimal ObterPercentualDesconto()
        {
            return .05m;
        }
    }

    public class Vip : EstrategiaDesconto
    {
        protected override decimal ObterPercentualDesconto()
        {
            return .1m;
        }

        protected override decimal ObterValorDescontoAdicional()
        {
            return 10m;
        }
    }
}
