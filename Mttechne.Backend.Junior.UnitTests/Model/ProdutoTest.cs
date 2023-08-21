using Mttechne.Backend.Junior.Services.Model;
using Mttechne.Backend.Junior.Services.Services;
using Mttechne.Backend.Junior.UnitTests.Mock;
using Xunit.Sdk;

namespace Mttechne.Backend.Junior.UnitTests.Model;

public class ProdutoTest
{
    [Fact]
    public void ShouldCreateAProductWithSuccess()
    {
        var teclado = new Produto() { Nome = "Teclado", Valor = 100 };
        
        Assert.Equal(100, teclado.Valor);
        Assert.Equal("Teclado", teclado.Nome);
    }

    //Testa a exception de string vazia do m�todo 
    [Fact]
    public void GetListaProdutoPorNomeTestValidation()
    {
        var produtoService = new ProdutoService();

        var produtosFiltrados = produtoService.GetListaProdutosPorNome("Mem�ria");

        Assert.Throws<ArgumentNullException>(() => produtoService.GetListaProdutosPorNome(null));
    }

    [Fact]
    public void GetListaProdutoPorNomeTestFilter()
    {
        var produtoService = new ProdutoService();

        var produtosFiltrados = produtoService.GetListaProdutosPorNome("Mem�ria");

        // Testa a qtd de itens mockados na lista
        Assert.Equal(produtosFiltrados.Count, 2);

        var produtosTeste = produtosFiltrados.Where(x => !x.Nome.Equals("Mem�ria")).ToList();

        // Testa se existe algum item na lista de produtos filtrados que n�o seja igual filtro especificado
        Assert.Equal(produtosTeste.Count, 0);
    }

    [Fact]
    public void GetProdutosOrdenadosTestValidation()
    {
        var produtoService = new ProdutoService();

        // Testa a exce��o de n�o especifica��o do tipo de ordena��o
        Assert.Throws<ArgumentNullException>(() => produtoService.GetProdutosOrdenadosPorValor(null));
    }

    [Fact]
    public void GetProdutosOrdenadosTestArgumentValidation()
    {
        var produtoService = new ProdutoService();

        // Teste a exce��o de especifica��o incorreta do tipo de ordena��o
        Assert.Throws<ArgumentException>(() => produtoService.GetProdutosOrdenadosPorValor("Teste"));
    }

    [Fact]
    public void GetProdutosOrdenadosTestOrderAsc()
    {
        var produtoService = new ProdutoService();

        var produtosOrdenados = produtoService.GetProdutosOrdenadosPorValor("crescente");

        // Testa a ordena��o crescente dos valores dos produtos
        Assert.Equal(produtosOrdenados.First().Valor, 300);
        Assert.Equal(produtosOrdenados.Last().Valor, 2100);
    }

    [Fact]
    public void GetProdutosOrdenadosTestOrderDesc()
    {
        var produtoService = new ProdutoService();

        var produtosOrdenados = produtoService.GetProdutosOrdenadosPorValor("decrescente");

        // Testa a ordena��o decrescente dos valores dos produtos
        Assert.Equal(produtosOrdenados.First().Valor, 2100);
        Assert.Equal(produtosOrdenados.Last().Valor, 300);
    }

    [Fact]
    public void GetProdutosPorFaixaDePrecoTestArgumentValidation()
    {
        var produtoService = new ProdutoService();

        // Teste a exce��o de especifica��o do campo valor
        Assert.Throws<ArgumentException>(() => produtoService.GetProdutosFiltradosPorFaixaDePreco(0, 350));
    }

    [Fact]
    public void GetProdutosPorFaixaDePrecoTest()
    {
        var produtoService = new ProdutoService();

        var produtos = produtoService.GetProdutosFiltradosPorFaixaDePreco(1000, 1500);

        // Verificando se tem produtos com valor maior que 1500 
        var maiorQue = produtos.Any(x => x.Valor > 1500);

        // Testando a valida��o de n�o ter produtos com valor maior que 1500 
        Assert.Equal(maiorQue, false);

        var menorQue = produtos.Any(x => x.Valor < 1000);

        Assert.Equal(menorQue, false);
    }

    [Fact]
    public void GetValorMaximoTestGrouping()
    {
        var produtoService = new ProdutoService();

        var listaProdutos = produtoService.GetValorMaximo();

        var listaEsperada = ProdutoServiceMock.ProdutosValorMaximoPorNome();

        bool isValidado = true;

        foreach (var produto in listaProdutos)
        {
            var produtoEsperado = listaEsperada.Where(x => x.Nome == produto.Nome && x.Valor == produto.Valor).FirstOrDefault();

            isValidado = produtoEsperado != null ? true : false;

            if (!isValidado)
                break;
        }

        Assert.Equal(isValidado, true);
    }

    [Fact]
    public void GetValorMinimoTestGrouping()
    {
        var produtoService = new ProdutoService();

        var listaProdutos = produtoService.GetValorMinimo();

        var listaEsperada = ProdutoServiceMock.ProdutosValorMinimoPorNome();

        bool isValidado = true;

        // Percorrendo a lista p/ encontrar um valor correspondente na lista de mock 
        foreach (var produto in listaProdutos)
        {

            var produtoEsperado = listaEsperada.Where(x => x.Nome == produto.Nome && x.Valor == produto.Valor).FirstOrDefault();

            isValidado = produtoEsperado != null ? true : false;

            if (!isValidado)
                break;
        }

        // Testando a correspondencia das listas 
        Assert.Equal(isValidado, true);
    }
}