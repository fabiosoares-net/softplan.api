using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Softplan.Projeto2.Api.Helper
{
    public class TempoInvalidoException : Exception
    {
        public TempoInvalidoException() : base() { }

        public TempoInvalidoException(string message) : base(message) { }
    }
}
