using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.Projeto2.Api.Helper
{
    public class ValorInicialInvalidoException : Exception
    {
        public ValorInicialInvalidoException() : base() { }

        public ValorInicialInvalidoException(string message) : base(message) { }
    }
}
