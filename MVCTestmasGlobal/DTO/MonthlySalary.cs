using MVCTestmasGlobal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestmasGlobal.DTO
{
    public class MonthlySalary : BaseEmployee
    {             
        public override decimal CalculateAnnualSalary(decimal monthlySalary)
        {
            return monthlySalary * 12;
        }        
    }
}
