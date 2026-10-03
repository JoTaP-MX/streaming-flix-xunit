using StreamingFlix.App;
using Xunit;

namespace StreamingFlix.Tests;

public class StreamingFlixTests
{
    private readonly PlanoStreamingService _service = new();

    [Theory]
    [InlineData(1, "BÁSICO")]
    [InlineData(2, "PADRÃO")]
    [InlineData(4, "PREMIUM")]
    public void ObterClassificacaoPorQualidade_DeveRetornarClassificacaoCorreta(
        int telasSimultaneas, string esperado)
    {
        var resultado = _service.ObterClassificacaoPorQualidade(telasSimultaneas);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(50, 1, 50)]  
    [InlineData(50, 6, 45)]   
    [InlineData(50, 12, 40)]  
    public void CalcularMensalidadeComDesconto_DeveAplicarDescontoCorreto(
        int valorBase, int mesesContratados, int esperado)
    {
        var resultado = _service.CalcularMensalidadeComDesconto(valorBase, mesesContratados);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(20, false, true)]   
    [InlineData(20, true, false)]   
    [InlineData(16, false, false)] 
    public void PodeAcessarConteudoAdulto_DeveValidarAcessoCorretamente(
        int idade, bool controleParentalAtivo, bool esperado)
    {
        var resultado = _service.PodeAcessarConteudoAdulto(idade, controleParentalAtivo);

        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(50, 5, 50)]    
    [InlineData(50, 11, 45)]   
    [InlineData(50, 24, 40)]   
    public void CalcularMensalidadeComDesconto_DeveRespeitarLimitesDasFaixas(
        int valorBase, int mesesContratados, int esperado)
    {
        var resultado = _service.CalcularMensalidadeComDesconto(valorBase, mesesContratados);

        Assert.Equal(esperado, resultado);
    }
}