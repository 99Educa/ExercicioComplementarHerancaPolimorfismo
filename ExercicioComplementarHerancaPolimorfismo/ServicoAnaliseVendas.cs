using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioComplementarHerancaPolimorfismo
{
    public class ServicoAnaliseVendas
    {
        public EstrategiaDesconto CriarEstrategiaDesconto(IList<PedidoVenda> pedidosVenda)
        {
            if (pedidosVenda == null || pedidosVenda.Count() == 0)
                return new Novo();

            var ultimaVenda = pedidosVenda.Max(p => p.DataVenda).Date;
            if (DateTime.Now.Date.Subtract(ultimaVenda).TotalDays > 180)
                return new Inativo();

            var comprasNosUltimos3Meses = pedidosVenda.Where(p => DateTime.Now.Date.Subtract(p.DataVenda.Date).TotalDays <= 90).ToList();
            if (comprasNosUltimos3Meses.Count <= 3)
                return new Recorrente();

            return new Vip();
        }
    }
}
