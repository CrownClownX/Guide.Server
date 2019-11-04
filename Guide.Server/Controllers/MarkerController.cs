using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guide.Api.ViewModels;
using Guide.Services.Dtos;
using Guide.Services.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Guide.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MarkerController : ControllerBase
    {
        private readonly IMarkerService _markerService;
        private readonly ILogger _logger;

        public MarkerController(IMarkerService markerService, ILogger<MarkerController> logger)
        {
            _markerService = markerService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarker(long id)
        {
            var response = new Response<MarkerDto>();

            try
            {
                response.Object = await _markerService.GetMarker(id);
            }
            catch(Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"MarkerController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetMarkers(long id)
        {
            var response = new ResponseCollection<MarkerDto>();

            try
            {
                response.Objects = await _markerService.GetMarkers();
            }
            catch (Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"MarkerController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetMarkersByUserId(long id)
        {
            var response = new ResponseCollection<MarkerDto>();

            try
            {
                response.Objects = await _markerService.GetMarkersByUserId(id);
            }
            catch (Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"MarkerController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMarker([FromBody]MarkerDto marker)
        {
            var response = new Response<MarkerDto>();

            try
            {
                response.Object = await _markerService.CreateMarker(marker);
            }
            catch (Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"MarkerController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }

        [HttpDelete("{markerId}")]
        public async Task<IActionResult> DeleteMarker(long markerId)
        {
            var response = new Response<MarkerDto>();

            try
            {
                await _markerService.DeleteMarker(markerId);
            }
            catch (Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"MarkerController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMarker([FromBody]MarkerDto marker)
        {
            var response = new Response<MarkerDto>();

            try
            {
                response.Object = await _markerService.UpdateMarker(marker);
            }
            catch (Exception e)
            {
                response.IsError = true;
                response.ErrorMessage = e.Message;

                _logger.LogError($"MarkerController | Error | Error message : {e.Message}");
            }

            return Ok(response);
        }
    }
}