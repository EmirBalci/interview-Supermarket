using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Core.Domains;
using Supermarket.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Login")]
        public async Task<User> Login(string username, string password)
        {
            var res = await _userService.Login(username, password);
            return res;
        }

        [HttpGet("GetUserById")]
        public async Task<User> GetUserById(Guid id)
        {
            var res = await _userService.GetUserById(id);
            return res;
        }
    }
}
