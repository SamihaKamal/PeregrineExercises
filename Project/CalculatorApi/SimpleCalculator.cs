using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class SimpleCalculator : ISimpleCalculator
    {
        private readonly ILog _log;
        private HttpClient a = new HttpClient();
  
        public SimpleCalculator(ILog logSP)
        {
            _log = logSP;
 
        }

        public async Task<int> add(int start, int amount)
        {
            int result;

            HttpResponseMessage response = await a.GetAsync($"https://localhost:44344/api/multiply?num1={start}&num2={amount}");
            string apiResult = await response.Content.ReadAsStringAsync();

            result = int.Parse(apiResult);
            _log.LogMess($"{start} + {amount} = {result}");
            return start + amount;
        }

        public async Task<int> divide(int start, int by)
        {
            int result;

            HttpResponseMessage response = await a.GetAsync($"https://localhost:44344/api/divide?num1={start}&num2={by}");
            string apiResult = await response.Content.ReadAsStringAsync();

            result = int.Parse(apiResult);
            _log.LogMess($"{start} / {by} = {result}");
       
            return result;
        }

        public async Task<int> multiply(int start, int by)
        {
            int result;
            
            HttpResponseMessage response = await a.GetAsync($"https://localhost:44344/api/multiply?num1={start}&num2={by}");
            string apiResult = await response.Content.ReadAsStringAsync();
            
            result = int.Parse(apiResult);
  
           
            _log.LogMess($"{start} * {by} = {result}");
     
            return result;
        }

        public async Task<int> subtract(int start, int amount)
        {
            int result;

            HttpResponseMessage response = await a.GetAsync($"https://localhost:44344/api/subtract?num1={start}&num2={amount}");
            string apiResult = await response.Content.ReadAsStringAsync();

            result = int.Parse(apiResult);
            _log.LogMess($"{start} - {amount} = {result}");
         
            return result;
        }

       
    }
}
