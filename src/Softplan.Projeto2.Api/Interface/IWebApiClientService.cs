using Softplan.Projeto2.Api.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.Projeto2.Api.Interface
{
    public interface IWebApiClientService
    {
        JurosDTO ObterTaxaJuros(string uri);
    }
}
