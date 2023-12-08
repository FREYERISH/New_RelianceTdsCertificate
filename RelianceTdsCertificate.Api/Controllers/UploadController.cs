using Microsoft.AspNetCore.Mvc;

namespace RelianceTdsCertificate.Api.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadFiles([FromBody] IEnumerable<FileInfo> files)
        {
            // Validate file data and save to storage
            try
            {
                foreach (var file in files)
                {
                    // Validate file size, type, etc.
                    // Save file data to storage (e.g., database, filesystem)
                }

                return Ok("Files uploaded successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}
