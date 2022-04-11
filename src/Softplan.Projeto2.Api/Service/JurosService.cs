using Softplan.Projeto2.Api.Helper;
using Softplan.Projeto2.Api.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.Projeto2.Api.Service
{
    public class JurosService : IJurosService
    {
        private readonly IWebApiClientService _webApiClientService;

        public JurosService(IWebApiClientService webApiClientService)
        {
            _webApiClientService = webApiClientService;
        }

        public string CalculaJuros(decimal valorInicial, int tempo)
        {
            ValidarObrigatoriedade(valorInicial, tempo);

            var taxaJuros = _webApiClientService.ObterTaxaJuros("juros/taxajuros");

            if (taxaJuros == null)
            {
                throw new TaxaJurosNulaException("Não foi possivel calcular o valor de juros, tente novamente mais tarde!");
            }

            var valorFinal = Math.Pow(Decimal.ToDouble(valorInicial) * (1 + taxaJuros.Taxa), tempo);

            var valorResultado = MontarValor(valorFinal);

            return valorResultado;
        }

        private void ValidarObrigatoriedade(decimal valorInicial, int tempo)
        {
            if (valorInicial == 0)
            {
                throw new ValorInicialInvalidoException($"O Valor Inicial: {valorInicial} não pode ser 0");
            }

            if (valorInicial < 0)
            {
                throw new ValorInicialInvalidoException($"O Valor Inicial: {valorInicial} não pode ser um valor negativo");
            }

            if (tempo < 1 || tempo > 12)
            {
                throw new TempoInvalidoException($"O Tempo: {tempo} não é um valor de Mês valido");
            }
        }

        private string MontarValor(double valorFinal)
        {
            var valor = Convert.ToString(valorFinal);

            if (valor.Length >= 5)
            {
                valor = valor.Substring(0, 5);
                valor = valor.Contains(",") ? valor : valor.Insert(valor.Length - 2, ",");
            }

            return valor;
        }
    }
}
