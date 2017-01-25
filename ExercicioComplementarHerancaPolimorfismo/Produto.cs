using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExercicioComplementarHerancaPolimorfismo
{
    public class Produto
    {
        public string Descricao { get; private set; }
        public decimal PrecoVenda { get; private set; }

        public Produto(string descricao, decimal precoVenda)
        {
            Descricao = descricao;
            PrecoVenda = precoVenda;
        }
    }
}
