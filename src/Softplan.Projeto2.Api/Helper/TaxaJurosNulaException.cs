using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.Projeto2.Api.Helper
{
    public class TaxaJurosNulaException : Exception
    {
        public TaxaJurosNulaException() : base() { }

        public TaxaJurosNulaException(string message) : base(message) { }
    }
}
