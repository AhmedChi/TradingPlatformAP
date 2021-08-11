using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace TradingPlatformAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LiveDataController : ControllerBase
    {
        private const string _YourAPIKey = "5T1HJR9WNB0F7TNP";
        private readonly IHttpClientFactory _httpClientFactory;
        private string errorMessage;

        public LiveDataController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("GetLiveDataWithAlphaVantage")]
        [EnableCors]
        public async Task<dynamic> Alpha()
        {
            dynamic stock = null;

            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=IBM&apikey=5T1HJR9WNB0F7TNP");

            var client = _httpClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();

                stock = JsonConvert.DeserializeObject(jsonString);

                return Ok(stock);
            }
            else
            {
                errorMessage = ($"Error found when trying to read stock equities api. Due to {response.ReasonPhrase}");
            }

            return stock;
        }
    }
}
