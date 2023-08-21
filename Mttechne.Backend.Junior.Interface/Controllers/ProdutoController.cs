using Microsoft.AspNetCore.Mvc;
using Mttechne.Backend.Junior.Services.Services;

namespace Mttechne.Backend.Junior.Interface.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private static IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetListaProdutos() => Ok(_service.GetListaProdutos());

    [HttpGet("filter/{nome}")]
    public async Task<IActionResult> GetListaProdutosProNome([FromRoute] string nome) => Ok(_service.GetListaProdutosPorNome(nome));

    [HttpGet("busca-ordenada/{tipo}")]
    public async Task<IActionResult> BuscaOrdenada([FromRoute] string tipo) => Ok(_service.GetProdutosOrdenadosPorValor(tipo));

    [HttpGet("busca-ordenada/{valor1}/{valor2}")]
    public async Task<IActionResult> ProdutosPorFaixaDePreço([FromRoute] int valor1, int valor2) => Ok(_service.GetProdutosFiltradosPorFaixaDePreco(valor1, valor2));

    [HttpGet("busca-maior-valor")]
    public async Task<IActionResult> GetValorMaximo() => Ok(_service.GetValorMaximo());

    [HttpGet("busca-menor-valor")]
    public async Task<IActionResult> GetValorMinimo() => Ok(_service.GetValorMinimo());
}