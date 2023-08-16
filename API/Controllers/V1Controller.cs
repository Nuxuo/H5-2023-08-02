using H5_CASE_2023_API.Context;
using H5_CASE_2023_API.Models;
using H5_CASE_2023_API.Models.Packages;
using H5_CASE_2023_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace H5_CASE_2023_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class V1Controller : Controller
    {
        private readonly IV1 _repos;

        public V1Controller(IV1 context)
        {
            _repos = context ?? throw new NullReferenceException(nameof(context));
        }

        [HttpGet("AccessRequest/keycard")]
        public IActionResult AccessKeycardRequest([FromBody] KeycardRequest accessRequest)
        {
            return _repos.Access_Keycard_Request(accessRequest) == false ? NotFound() : Ok();
        }


        [HttpGet("AccessRequest/code")]
        public IActionResult AccessCodeRequest([FromBody] CodeRequest accessRequest)
        {
            return _repos.Access_Code_Request(accessRequest) == false ? NotFound() : Ok();
        }

        [HttpGet("SetupRequest")]
        public IActionResult SetupRequest([FromBody] SetupRequest setupRequest)
        {
            var _temp = _repos.Setup_Request(setupRequest);
            return _temp == null ? NotFound() : Ok(_temp);
        }

        [HttpPost("Data/Conditions")]
        public IActionResult DataConditionsPost([FromBody] ConditionsPost conditionsPost)
        {
            return _repos.Conditions_Post(conditionsPost) == false ? NotFound() : Ok();
        }

        [HttpPost("Data/Alarm")]
        public IActionResult DataAlarmPost([FromBody] AlarmPost alarmPost)
        {
            return _repos.Alarm_Post(alarmPost) == false ? NotFound() : Ok();
        }
    }
}
