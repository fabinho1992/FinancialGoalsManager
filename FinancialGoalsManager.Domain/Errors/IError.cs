using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Errors
{
    public interface IError
    {
        //A palavra-chave init é usada para definir um tipo especial de acessador set
        public string Code { get; init; }
        public string Message { get; init; }
    }
}
