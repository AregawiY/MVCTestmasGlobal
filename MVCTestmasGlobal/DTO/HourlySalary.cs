using MVCTestmasGlobal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCTestmasGlobal.DTO
{
    public class HourlySalary : BaseEmployee
    {          
        public override decimal CalculateAnnualSalary(decimal hourlySalary)
        {
            return hourlySalary * 120 * 12;
        }       
    }
}
