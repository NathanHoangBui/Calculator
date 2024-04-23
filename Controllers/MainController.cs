using Calculator.Model;
using Calculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Calculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private readonly CalculateServices calculateServices;

        public MainController()
        {
            this.calculateServices = new CalculateServices();
        }

        [HttpPost("calculate/json", Name = "calculate-json")]
        [Consumes("application/json")]
        public async Task<Double> CalculateMathsJSON([FromBody] JsonObject inputData)
        {
            // Check if the input data is XML form 
            try
            {
                return calculateServices.ProcessRequest(inputData); 
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
            }
            return 0.0;
        }
    }
}
