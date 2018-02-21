using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestmasGlobal.Models
{
    public abstract class BaseEmployee
    {   
        public abstract Decimal CalculateAnnualSalary(Decimal salary);
    }
}
