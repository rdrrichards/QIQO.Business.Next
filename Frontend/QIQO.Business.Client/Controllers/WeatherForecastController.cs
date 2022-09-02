using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace QIQO.Business.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DaprClient _daprClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountData[]>>> Get(CancellationToken cancellationToken)
        {
            // var result = await _daprClient.InvokeMethodAsync("account-api", "accounts", cancellationToken);
            var result = _daprClient.CreateInvokeMethodRequest(HttpMethod.Get, "accounts-api", "api/v1/accounts");
            var accounts = await _daprClient.InvokeMethodAsync<AccountData[]>(result, cancellationToken);
            return Ok(accounts);
        }
    }

    public class AccountData
    {
        public int AccountKey { get; set; }
        public int CompanyKey { get; set; }
        public int AccountType { get; set; }
        public string AccountCode { get; set; } = string.Empty;
        public string AccountName { get; set; } = string.Empty;
        public string AccountDesc { get; set; } = string.Empty;
        public string AccountDba { get; set; } = string.Empty;
        public DateTime AccountStartDate { get; set; }
        public DateTime? AccountEndDate { get; set; }
        public string AddedUserID { get; set; } = string.Empty;
        public DateTime AddedDateTime { get; set; }
        public string UpdateUserID { get; set; } = string.Empty;
        public DateTime? UpdateDateTime { get; set; }
    }

}