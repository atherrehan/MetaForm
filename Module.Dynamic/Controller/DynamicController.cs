using DynamicFlow.Models.DTOs;
using DynamicFlow.Models.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Module.Dynamic.Core.Services;

namespace Module.Dynamic.Controller
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class DynamicController(IDynamicService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUrls()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.GetURL();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetFlow([FromBody] DynamicFlowComponentRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.GetFlowDetail(requestDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> GetKeyValue([FromBody] GenericKeyValueRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.GetKeyValue(requestDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveFlow([FromBody] DynamicFlowComponentSaveRequestDto requestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.SaveFlow(requestDto);
            return Ok(response);
        }

    }
}
