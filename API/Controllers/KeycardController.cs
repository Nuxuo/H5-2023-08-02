using H5_CASE_2023_API.Context;
using H5_CASE_2023_API.Models;
using H5_CASE_2023_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace H5_CASE_2023_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeycardController : Controller
    {
        private readonly IKeycardRepository _repos;
        public KeycardController(IKeycardRepository context)
        {
            _repos = context ?? throw new NullReferenceException(nameof(context));
        }

        [HttpGet("{keycardGuid}/{serverRoomId}")]
        public IActionResult AccessKeycardRequest(string keycardGuid, int serverRoomId)
        {
            var employeeCode = _repos.Access_Keycard_Request(keycardGuid, serverRoomId);

            return employeeCode == null ? NotFound() : Ok(employeeCode);
        }
    }
}
