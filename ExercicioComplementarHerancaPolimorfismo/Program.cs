using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioComplementarHerancaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            TestarHerancaPolimorfismoClienteNovo();
            TestarHerancaPolimorfismoClienteInativo();
            TestarHerancaPolimorfismoClienteRecorrente();
            TestarHerancaPolimorfismoClienteVip();
            Console.ReadKey();
        }

        #region Exercício complementar Herança e Polimorfismo
        private static void TestarHerancaPolimorfismoClienteNovo()
        {
            var pedidos = new List<PedidoVenda>();
            var servicoAnaliseVendas = new ServicoAnaliseVendas();
            var estrategiaNovo = servicoAnaliseVendas.CriarEstrategiaDesconto(pedidos);

            var primeiroPedido = CriarPedidoVenda(DateTime.Now);

            Console.WriteLine("-------------------");
            Console.WriteLine("Testando estratégia de desconto para cliente novo");
            Console.WriteLine("-------------------");
            Console.WriteLine("Deve dar R$ 10,00 de desconto, pois o valor total do Pedido ultrapassa R$ 100,00...");
            Console.WriteLine(string.Format("Valor bruto do Pedido: {0}", primeiroPedido.ValorBruto.ToString("###,##0.00")));
            primeiroPedido.CalcularValorLiquido(estrategiaNovo);
            Console.WriteLine(string.Format("Valor líquido do Pedido após o desconto: {0}", primeiroPedido.ValorLiquido.ToString("###,##0.00")));
            Console.WriteLine("-------------------");
        }

        private static void TestarHerancaPolimorfismoClienteInativo()
        {
            var pedidos = new List<PedidoVenda>();
            var servicoAnaliseVendas = new ServicoAnaliseVendas();

            var pedido = CriarPedidoVenda(DateTime.Now.AddMonths(-7));
            pedidos.Add(pedido);

            var estrategiaInativo = servicoAnaliseVendas.CriarEstrategiaDesconto(pedidos);

            Console.WriteLine("-------------------");
            Console.WriteLine("Testando estratégia de desconto para cliente inativo");
            Console.WriteLine("-------------------");
            Console.WriteLine("Deve conceder 5% de desconto, pois o Pedido ultrapassa R$ 100,00...");
            Console.WriteLine(string.Format("Valor bruto do Pedido: {0}", pedido.ValorBruto.ToString("###,##0.00")));
            pedido.CalcularValorLiquido(estrategiaInativo);
            Console.WriteLine(string.Format("Valor líquido do Pedido após o desconto: {0}", pedido.ValorLiquido.ToString("###,##0.00")));
            Console.WriteLine("-------------------");
        }

        private static void TestarHerancaPolimorfismoClienteRecorrente()
        {
            var pedidos = new List<PedidoVenda>();
            var servicoAnaliseVendas = new ServicoAnaliseVendas();

            pedidos.Add(CriarPedidoVenda(DateTime.Now.AddDays(-90)));
            pedidos.Add(CriarPedidoVenda(DateTime.Now.AddDays(-80)));
            pedidos.Add(CriarPedidoVenda(DateTime.Now.AddDays(-70)));
            var estrategiaRecorrente = servicoAnaliseVendas.CriarEstrategiaDesconto(pedidos);

            var pedido = CriarPedidoVenda(DateTime.Now, 1, new Produto("Bola", 10));

            Console.WriteLine("-------------------");
            Console.WriteLine("Testando estratégia de desconto para cliente recorrente");
            Console.WriteLine("-------------------");
            Console.WriteLine("Deve conceder 5% de desconto, independentemente do valor bruto do Pedido...");
            Console.WriteLine(string.Format("Valor bruto do Pedido: {0}", pedido.ValorBruto.ToString("###,##0.00")));
            pedido.CalcularValorLiquido(estrategiaRecorrente);
            Console.WriteLine(string.Format("Valor líquido do Pedido após o desconto: {0}", pedido.ValorLiquido.ToString("###,##0.00")));
            Console.WriteLine("-------------------");
        }

        private static void TestarHerancaPolimorfismoClienteVip()
        {
            var pedidos = new List<PedidoVenda>();
            var servicoAnaliseVendas = new ServicoAnaliseVendas();

            pedidos.Add(CriarPedidoVenda(DateTime.Now.AddDays(-90)));
            pedidos.Add(CriarPedidoVenda(DateTime.Now.AddDays(-80)));
            pedidos.Add(CriarPedidoVenda(DateTime.Now.AddDays(-70)));
            pedidos.Add(CriarPedidoVenda(DateTime.Now.AddDays(-60)));
            var estrategiaVip = servicoAnaliseVendas.CriarEstrategiaDesconto(pedidos);

            var pedido = CriarPedidoVenda(DateTime.Now);

            Console.WriteLine("-------------------");
            Console.WriteLine("Testando estratégia de desconto para cliente VIP");
            Console.WriteLine("-------------------");
            Console.WriteLine("Deve conceder 10% de desconto + R$ 10,00 sobre o valor bruto...");
            Console.WriteLine(string.Format("Valor bruto do Pedido: {0}", pedido.ValorBruto.ToString("###,##0.00")));
            pedido.CalcularValorLiquido(estrategiaVip);
            Console.WriteLine(string.Format("Valor líquido do Pedido após o desconto: {0}", pedido.ValorLiquido.ToString("###,##0.00")));
            Console.WriteLine("-------------------");
        }

        private static PedidoVenda CriarPedidoVenda(DateTime dataVenda)
        {
            var cliente = new Cliente();
            var pedido = new PedidoVenda(dataVenda, cliente);
            var bola = new Produto("Bola", 10);
            var chuteira = new Produto("Chuteira", 100);
            pedido.Itens.Add(CriarPedidoVendaItem(pedido, 1, bola));
            pedido.Itens.Add(CriarPedidoVendaItem(pedido, 1, chuteira));

            return pedido;
        }

        private static PedidoVenda CriarPedidoVenda(DateTime dataVenda, int quantidade, Produto produto)
        {
            var cliente = new Cliente();
            var pedido = new PedidoVenda(dataVenda, cliente);
            pedido.Itens.Add(CriarPedidoVendaItem(pedido, 1, produto));

            return pedido;
        }

        private static PedidoVendaItem CriarPedidoVendaItem(PedidoVenda pedidoVenda, int quantidade, Produto produto)
        {
            return new PedidoVendaItem(pedidoVenda, quantidade, produto);
        }
        #endregion
    }
}
