using DigitalLibraryAPI.Models;
using DigitalLibraryAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalLibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository = null;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] SignupModel signupModel)
        {
            var result = await _accountRepository.SignUpAsync(signupModel);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signinModel)
        {
            var result = await _accountRepository.LoginAsync(signinModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
