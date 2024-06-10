using Microsoft.AspNetCore.Mvc;

using MY_WEB_APP.Models;
using MY_WEB_APP.Repositories;
using MY_WEB_APP.Services;

namespace MY_WEB_APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        // Raw Data Endpoints

        [HttpGet("raw")]
        public async Task<ActionResult<IEnumerable<RawData>>> GetAllRawData()
        {
            var rawData = await _dataService.GetAllRawDataAsync();
            return Ok(rawData);
        }

        [HttpGet("raw/{id}")]
        public async Task<ActionResult<RawData>> GetRawDataById(int id)
        {
            var rawData = await _dataService.GetRawDataByIdAsync(id);
            if (rawData == null)
            {
                return NotFound();
            }
            return Ok(rawData);
        }

        [HttpPost("raw")]
        public async Task<ActionResult<RawData>> AddRawData(RawData rawData)
        {
            var createdRawData = await _dataService.AddRawDataAsync(rawData);
            return CreatedAtAction(nameof(GetRawDataById), new { id = createdRawData.Id }, createdRawData);
        }

        [HttpPut("raw/{id}")]
        public async Task<IActionResult> UpdateRawData(int id, RawData rawData)
        {
            if (id != rawData.Id)
            {
                return BadRequest();
            }

            await _dataService.UpdateRawDataAsync(rawData);
            return NoContent();
        }

        [HttpDelete("raw/{id}")]
        public async Task<IActionResult> DeleteRawData(int id)
        {
            var success = await _dataService.DeleteRawDataAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Transformed Data Endpoints

        [HttpGet("transformed")]
        public async Task<ActionResult<IEnumerable<TransformedData>>> GetAllTransformedData()
        {
            var transformedData = await _dataService.GetAllTransformedDataAsync();
            return Ok(transformedData);
        }

        [HttpGet("transformed/{id}")]
        public async Task<ActionResult<TransformedData>> GetTransformedDataById(int id)
        {
            var transformedData = await _dataService.GetTransformedDataByIdAsync(id);
            if (transformedData == null)
            {
                return NotFound();
            }
            return Ok(transformedData);
        }

        [HttpPost("transformed")]
        public async Task<ActionResult<TransformedData>> AddTransformedData(TransformedData transformedData)
        {
            var createdTransformedData = await _dataService.AddTransformedDataAsync(transformedData);
            return CreatedAtAction(nameof(GetTransformedDataById), new { id = createdTransformedData.Id }, createdTransformedData);
        }

        [HttpPut("transformed/{id}")]
        public async Task<IActionResult> UpdateTransformedData(int id, TransformedData transformedData)
        {
            if (id != transformedData.Id)
            {
                return BadRequest();
            }

            await _dataService.UpdateTransformedDataAsync(transformedData);
            return NoContent();
        }

        [HttpDelete("transformed/{id}")]
        public async Task<IActionResult> DeleteTransformedData(int id)
        {
            var success = await _dataService.DeleteTransformedDataAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Data Transformation Endpoints

        [HttpPost("transform")]
        public async Task<IActionResult> TransformAndSaveData(RawData rawData)
        {
            await _dataService.TransformAndSaveDataAsync(rawData);
            return Ok();
        }

        [HttpGet("transformedData")]
        public async Task<ActionResult<IEnumerable<TransformedData>>> GetTransformedData()
        {
            var transformedData = await _dataService.GetTransformedDataAsync();
            return Ok(transformedData);
        }
    }
}
