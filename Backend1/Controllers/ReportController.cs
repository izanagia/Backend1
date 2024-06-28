using Microsoft.AspNetCore.Mvc;
using Backend.DataAccess;
using Backend1.Model;

namespace Backend.Controllers
{
    [Route("report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportContext _context;

        public ReportController(ReportContext context)
        {
            _context = context;
        }

        [HttpPost("user")]
        public async Task<IActionResult> CreateReport([FromBody] Report report)
        {
            report.Id = Guid.NewGuid();
            report.CreatedAt = DateTime.UtcNow;
            report.Progress = 0;
            report.Result = null;
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
            return Ok(report.Id);
        }

        [HttpGet("info")]
        public async Task<IActionResult> GetReportInfo([FromQuery] Guid id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }
            return Ok(report);
        }

        [HttpPost("process")]
        public async Task<IActionResult> ProcessReport([FromQuery] Guid id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            for (int i = 1; i <= 6; i++)
            {
                await Task.Delay(10000); 
                report.Progress = i * 15;
                if (i == 6)
                {
                    report.Result = "Completed";
                }
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
