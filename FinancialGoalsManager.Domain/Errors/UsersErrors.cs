using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialGoalsManager.Domain.Errors
{
    public class UsersErrors
    {
        public static readonly Error NotFound = new(
            "Users.NotFoud", "The User could not be found");
            
    }
}
