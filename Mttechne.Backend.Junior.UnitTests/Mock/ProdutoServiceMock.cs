using Mttechne.Backend.Junior.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mttechne.Backend.Junior.UnitTests.Mock
{
    public class ProdutoServiceMock
    {
        // Listas com dados para comparação 
        public static List<Produto> ProdutosValorMaximoPorNome()
        {
            Produto produto2 = new Produto() { Nome = "Placa de Vídeo", Valor = 1500 };
            Produto produto5 = new Produto() { Nome = "Processador", Valor = 2100 };
            Produto produto7 = new Produto() { Nome = "Memória", Valor = 350 };
            Produto produto8 = new Produto() { Nome = "Placa mãe", Valor = 1100 };

            var produtosCadastrados = new List<Produto>()
            {
                produto2, produto5, produto7, produto8
            };

            return produtosCadastrados;
        }

        public static List<Produto> ProdutosValorMinimoPorNome()
        {
            Produto produto1 = new Produto() { Nome = "Placa de Vídeo", Valor = 1000 };
            Produto produto4 = new Produto() { Nome = "Processador", Valor = 2000 };
            Produto produto6 = new Produto() { Nome = "Memória", Valor = 300 };
            Produto produto8 = new Produto() { Nome = "Placa mãe", Valor = 1100 };

            var produtosCadastrados = new List<Produto>()
            {
                produto1, produto4, produto6, produto8
            };

            return produtosCadastrados;
        }
    }
}
