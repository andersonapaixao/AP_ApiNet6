using AP_ApiNet6.Application.DTOs;
using AP_ApiNet6.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AP_ApiNet6.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonImageController : ControllerBase
    {
        private readonly IPersonImageService _personImageService;

        public PersonImageController(IPersonImageService personImageService)
        {
            _personImageService = personImageService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateImageBase64Async(PersonImageDTO personImageDTO)
        {
            var result = await _personImageService.CreateImageBase64Async(personImageDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPost]
        [Route("pathimage")]
        public async Task<ActionResult> CreateImageAsync(PersonImageDTO personImageDTO)
        {
            var result = await _personImageService.CreateImageAsync(personImageDTO);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
