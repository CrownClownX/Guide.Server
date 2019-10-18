using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guide.Services.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Guide.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public ValuesController(IUserService userService, ILogger<ValuesController> logger)
        {
            _userService = userService;
            _logger = logger;

            logger.LogDebug("Ctor");
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<object>> Get()
        {
            var users = await _userService.GetUsers();

            return users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
