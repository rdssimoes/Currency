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
    public class SegmentController : ControllerBase
    {
        private readonly ILogger<SegmentController> _logger;
        private readonly IConfiguration _configuration;
        private readonly ISegmentService _segmentService;

        public SegmentController(ILogger<SegmentController> logger, IConfiguration configuration, ISegmentService segmentService)
        {
            _logger = logger;
            _configuration = configuration;
            _segmentService = segmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Segment> segs = await _segmentService.FindAll();
            return new JsonResult(segs);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Segment seg)
        {
            bool ret = await _segmentService.Update(seg);

            return new JsonResult(ret ? "Alteração efetuada com sucesso" : "Não foi possível fazer a alteração");
        }
    }
}
