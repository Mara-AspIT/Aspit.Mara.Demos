using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aspit.Mara.Demos.WebService
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EmployeeWebService webService = new EmployeeWebService();
                Employee test = webService.GetSingle();
                Console.WriteLine(test);
            }
            catch(Exception)
            {

                throw;
            }
            Console.ReadLine();
        }
    }

    class EmployeeWebService
    {
        readonly string url = @"http://dummy.restapiexample.com/api/v1/employee";

        public Employee GetSingle(int id = 20979)
        {
            string urlForSingle = $"{url}/{id}";
            try
            {
                Task<string> resultTask = CallWebApi(urlForSingle);
                return (Employee)UnpackFrom(resultTask.Result);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<Employee> GetMany()
        {
            string urlForMany = $"{url}s";
            try
            {
                Task<string> resultTask = CallWebApi(urlForMany);
            }
            catch(Exception)
            {
                throw;
            }
            throw new NotImplementedException();
        }

        private async Task<string> CallWebApi(string url)
        {
            using(HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        private JsonEmployee UnpackFrom(string json)
        {
            return JsonConvert.DeserializeObject<JsonEmployee>(json);
        }
    }

    class JsonEmployee
    {
        public int Id { get; set; }
        public string Employee_Name { get; set; }
        public decimal Employee_Salary { get; set; }

        public static explicit operator Employee(JsonEmployee jsonEmployee)
        {
            return new Employee() { Id = jsonEmployee.Id, Name = jsonEmployee.Employee_Name, Salary = jsonEmployee.Employee_Salary };
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
            => $"{Id}, {Name}, {Salary}";
    }
}
