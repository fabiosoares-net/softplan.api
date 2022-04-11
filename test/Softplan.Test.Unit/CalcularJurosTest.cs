using Moq;
using Softplan.Projeto2.Api.Helper;
using Softplan.Projeto2.Api.Interface;
using Softplan.Projeto2.Api.Model;
using Softplan.Projeto2.Api.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Softplan.Test.Unit
{
    public class CalcularJurosTest
    {
        [Theory]
        [InlineData("105,10", 100, 5)]
        [InlineData("50,5", 50, 1)]
        public void CalculaJuros_ValoresValidos_RetornaValorCalculadoDoJurosComSucesso(string valorEsperado, decimal valorInicial, int tempo)
        {
            Mock<IWebApiClientService> webApiClientService = new Mock<IWebApiClientService>();
            webApiClientService.Setup(x => x.ObterTaxaJuros("juros/taxajuros")).Returns(new JurosDTO() { Taxa = 0.01 });

            var jurosService = new JurosService(webApiClientService.Object);

            var jurosResultado = jurosService.CalculaJuros(valorInicial, tempo);

            Assert.Equal(valorEsperado, jurosResultado);
        }

        [Theory]
        [InlineData(100, 5)]
        public void CalculaJuros_ValoresValidos_RetornaTaxaJurosNulaExceptionValorDaTaxaRetornaNula(decimal valorInicial, int tempo)
        {
            Mock<IWebApiClientService> webApiClientService = new Mock<IWebApiClientService>();
            webApiClientService.Setup(x => x.ObterTaxaJuros("juros/taxajuros")).Returns((JurosDTO)null);

            var jurosService = new JurosService(webApiClientService.Object);

            Assert.Throws<TaxaJurosNulaException>(() => jurosService.CalculaJuros(valorInicial, tempo));
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(-200, 5)]
        public void CalculaJuros_ValorInicialInvalido_RetornaValorInicialInvalidoExceptionDoValorInicialIncorreto(decimal valorInicial, int tempo)
        {
            Mock<IWebApiClientService> webApiClientService = new Mock<IWebApiClientService>();
            webApiClientService.Setup(x => x.ObterTaxaJuros("juros/taxajuros")).Returns(new JurosDTO() { Taxa = 0.01 });

            var jurosService = new JurosService(webApiClientService.Object);

            Assert.Throws<ValorInicialInvalidoException>(() => jurosService.CalculaJuros(valorInicial, tempo));
        }

        [Theory]
        [InlineData(300, 0)]
        [InlineData(200, -10)]
        [InlineData(200, 14)]
        public void CalculaJuros_TempoInvalido_RetornaTempoInvalidoExceptionDoValorDeTempoIncorreto(decimal valorInicial, int tempo)
        {
            Mock<IWebApiClientService> webApiClientService = new Mock<IWebApiClientService>();
            webApiClientService.Setup(x => x.ObterTaxaJuros("juros/taxajuros")).Returns(new JurosDTO() { Taxa = 0.01 });

            var jurosService = new JurosService(webApiClientService.Object);

            Assert.Throws<TempoInvalidoException>(() => jurosService.CalculaJuros(valorInicial, tempo));
        }
    }
}
