using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exchange.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly ILogger<SegmentController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ICountryService _countryService;

        public CountryController(ILogger<SegmentController> logger, IConfiguration configuration, ICountryService countryService)
        {
            _logger = logger;
            _configuration = configuration;
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Country> cou = await _countryService.FindAll();
            return new JsonResult(cou);
        }
    }
}