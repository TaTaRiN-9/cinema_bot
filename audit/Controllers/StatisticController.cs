using audit.FileService;
using Microsoft.AspNetCore.Mvc;

namespace audit.Controllers
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticController : ControllerBase
    {
        private readonly IFileAction _fileAction;
        public StatisticController(IFileAction fileAction)
        {
            _fileAction = fileAction;
        }

        [HttpGet("{chat_id}")]
        public async Task<IActionResult> GetStatistics(Guid chat_id)
        {
            var result = await _fileAction.Read(chat_id);

            return Ok(result);
        }
    }
}
