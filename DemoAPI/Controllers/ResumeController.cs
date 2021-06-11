using DemoAPI.Interfaces;
using DemoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;
        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Resume>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult CreateResume([FromForm] Resume resume)
        {
            try
            {
                _resumeService.AddResume(resume);

                return Ok(new
                {
                    message = "Insert Resume Success.",
                    status = 200
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.InnerException.Message,
                    status = 400
                });
            }
        }
    }
}
