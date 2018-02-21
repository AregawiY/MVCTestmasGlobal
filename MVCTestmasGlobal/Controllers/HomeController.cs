using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCTestmasGlobal.DTO;
using MVCTestmasGlobal.Models;
using Newtonsoft.Json;

namespace MVCTestmasGlobal.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index(int EmployeeId)
        {
            List<Employee> emplist = new List<Employee>();
            emplist = await AsyncEmployee();
            if(EmployeeId > 0)
            {
                emplist = emplist.Where(s => s.id == EmployeeId).ToList();
            }
            
            foreach (var emp in emplist)
            {
                if (emp.contractTypeName == "MonthlySalaryEmployee")
                {
                    var objMonthlySalary = new MonthlySalary();
                    emp.annualSalary = objMonthlySalary.CalculateAnnualSalary(emp.monthlySalary);
                }
                else if (emp.contractTypeName == "HourlySalaryEmployee")
                {
                    var objHourlySalary = new HourlySalary();
                    emp.annualSalary = objHourlySalary.CalculateAnnualSalary(emp.hourlySalary);                   
                }

            }
  

            return View(emplist);
        }

        private async Task<List<Employee>> AsyncEmployee()
        {
            string baseUrl = "http://masglobaltestapi.azurewebsites.net/";
            List<Employee> emplist = new List<Employee>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/employees");

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    emplist = JsonConvert.DeserializeObject<List<Employee>>(response);
                }
            }
            return emplist;
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}