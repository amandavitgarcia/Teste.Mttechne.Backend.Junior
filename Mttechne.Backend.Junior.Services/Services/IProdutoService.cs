using Mttechne.Backend.Junior.Services.Model;

namespace Mttechne.Backend.Junior.Services.Services;

public interface IProdutoService
{
    List<Produto> GetListaProdutos();
    List<Produto> GetListaProdutosPorNome(string nome);
    List<Produto> GetProdutosOrdenadosPorValor(string ordem);
    List<Produto> GetProdutosFiltradosPorFaixaDePreco(int valor1, int valor2);
    List<Produto> GetValorMaximo();
    List<Produto> GetValorMinimo();

}