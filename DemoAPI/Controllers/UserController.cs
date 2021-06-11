using DemoAPI.Interfaces;
using DemoAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userService.GetAllUser();
                return Ok(new
                {
                    data = users,
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

        [HttpPost]
        public IActionResult PostUser([FromBody]User user)
        {
            try
            {
                var userDto = user.Adapt<Entities.User>();
                _userService.InsertUser(userDto);

                return Ok(new
                {
                    message = "Insert User Success.",
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
