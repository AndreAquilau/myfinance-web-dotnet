using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Infra.Data.Validate;

internal class RepositoryExceptionValitation : Exception
{
    public RepositoryExceptionValitation(string message) : base(message) { }

    public static void When(bool hasError, string error)
    {
        if (hasError) 
            throw new Exception(error);
    }
}

