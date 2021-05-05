using Exchange.Domain.Entities;
using Exchange.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Exchange.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateController : Controller
    {
        private readonly ILogger<SegmentController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISegmentService _segmentService;
        private readonly IRateService _rateService;

        public RateController(ILogger<SegmentController> logger, IConfiguration configuration, ISegmentService segmentService, IRateService rateService)
        {
            _logger = logger;
            _configuration = configuration;
            _segmentService = segmentService;
            _rateService = rateService;
        }

        [HttpPut]
        public async Task<IActionResult> Put(Rate rat)
        {
            await _rateService.Convert(rat, _segmentService);
            return new JsonResult(rat);
        }
    }
}