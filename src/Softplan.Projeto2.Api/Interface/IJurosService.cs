using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.Projeto2.Api.Interface
{
    public interface IJurosService
    {
        string CalculaJuros(decimal valorInicial, int tempo);
    }
}
