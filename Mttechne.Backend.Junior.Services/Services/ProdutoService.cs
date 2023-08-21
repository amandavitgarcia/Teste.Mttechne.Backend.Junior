using Mttechne.Backend.Junior.Services.Model;
using System.Globalization;
using System.Text;

namespace Mttechne.Backend.Junior.Services.Services;

public class ProdutoService : IProdutoService
{
    public List<Produto> GetListaProdutos()
    {
        Produto produto1 = new Produto() { Nome = "Placa de Vídeo", Valor = 1000 };
        Produto produto2 = new Produto() { Nome = "Placa de Vídeo", Valor = 1500 };
        Produto produto3 = new Produto() { Nome = "Placa de Vídeo", Valor = 1350 };
        Produto produto4 = new Produto() { Nome = "Processador", Valor = 2000 };
        Produto produto5 = new Produto() { Nome = "Processador", Valor = 2100 };
        Produto produto6 = new Produto() { Nome = "Memória", Valor = 300 };
        Produto produto7 = new Produto() { Nome = "Memória", Valor = 350 };
        Produto produto8 = new Produto() { Nome = "Placa mãe", Valor = 1100 };
        
        List<Produto> produtosCadastrados = new List<Produto>()
        {
            produto1, produto2, produto3, produto4, produto5, produto6, produto7, produto8
        };
        
        return produtosCadastrados;
    }

    public List<Produto> GetListaProdutosPorNome(string nome)
    {
        // Verifica se o campo nome está vazio ou contém espaço
        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new ArgumentNullException("O nome não pode estar vazio.");
        }

        var listaProdutos = GetListaProdutos();

        // Converte o nome para minúsculas e remove os acentos
        string nomeSemAcentos = RemoveAcentos(nome.ToLower());

        return listaProdutos.Where(x => RemoveAcentos(x.Nome.ToLower()).Contains(nomeSemAcentos))
        .ToList();
    }

    private string RemoveAcentos(string texto)
    {
        string textoSemAcento = "";

        // Loop que percorre os caracteres do texto
        foreach (char caractere in texto.Normalize(NormalizationForm.FormD))
        {
            // Decompondo os caracteres que possuem acento
            if (char.GetUnicodeCategory(caractere) != UnicodeCategory.NonSpacingMark)
            {
                textoSemAcento += caractere;
            }
        }
        // Retornando o texto sem acentos
        return textoSemAcento;
    }

    // Método que ordena valor dos produtos em ordem crescente
    public List<Produto> GetProdutosOrdenadosPorValor(string tipoOrdenacao)
    {
        // Verifica se o campo nome está vazio ou contém espaço
        if (string.IsNullOrWhiteSpace(tipoOrdenacao))
        {
            throw new ArgumentNullException("O nome não pode estar vazio.");
        }

        var listaProdutos = GetListaProdutos();

        if (tipoOrdenacao.ToLower() == "crescente")
            return listaProdutos.OrderBy(produto => produto.Valor).ToList();
        else if (tipoOrdenacao.ToLower() == "decrescente")
            return listaProdutos.OrderByDescending(produto => produto.Valor).ToList();
        else
            throw new ArgumentException("Paramêtro inválido.");
    }

    // Método que retorna por faixa de preço
    public List<Produto> GetProdutosFiltradosPorFaixaDePreco(int valor1, int valor2)
    {
        // Verifica se os campos valor1 e valor2 possuem valor <= 0 
        if (valor1 <= 0 || valor2 <= 0)
        {
            throw new ArgumentException("Parâmetro não pode ser menor ou igual a 0");
        }

        var listaProdutos = GetListaProdutos();

        // Instanciando uma nova lista de produtos
        List<Produto> produtosComValorEntre = new List<Produto>();

        // Percorrendo a lista de valores dos produtos
        foreach (Produto produto in listaProdutos)
        {
            // Verificando os valores entre 
            if (produto.Valor >= valor1 && produto.Valor <= valor2)
            {
                // Adicionando os valores entre à lista 
                produtosComValorEntre.Add(produto);
            }
        }

        return produtosComValorEntre;
    }

    // Método que busca por valores máximos 
    public List<Produto> GetValorMaximo()
    {
        var listaProdutos = GetListaProdutos();

        // Agrupando os produtos por nome
        var produtosAgrupados = listaProdutos.GroupBy(produto => produto.Nome);

        List<Produto> precoMaximo = new List<Produto>();

        // Percorrendo a lista de grupos de produtos
        foreach (var produtos in produtosAgrupados)
        {
            // Encontrando o maior valor por produto agrupado
            Produto produtoComMaiorValor = produtos.OrderByDescending(produto => produto.Valor).First();
            precoMaximo.Add(produtoComMaiorValor);
        }

        return precoMaximo;
    }

    // Método que busca por valores mínimos
    public List<Produto> GetValorMinimo()
    {
        var listaProdutos = GetListaProdutos();

        // Agrupando os produtos por nome
        var produtosAgrupados = listaProdutos.GroupBy(produto => produto.Nome);

        List<Produto> precoMinimo = new List<Produto>();

        // Percorrendo a lista de grupos de produtos
        foreach (var produtos in produtosAgrupados)
        {
            // Encontrando o maior valor por produto agrupado
            Produto produtoComMenorValor = produtos.OrderBy(produto => produto.Valor).First();
            precoMinimo.Add(produtoComMenorValor);
        }

        return precoMinimo;
    }
}