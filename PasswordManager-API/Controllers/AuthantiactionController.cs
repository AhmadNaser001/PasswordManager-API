using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PasswordManager_API.DTOs.Authantication;
using PasswordManager_API.Interfaces;

namespace PasswordManager_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthantiactionController : ControllerBase
    {
        private readonly IUserAuthanticationInterface _appService;
        public AuthantiactionController(IUserAuthanticationInterface appService)
        {
            _appService = appService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignUp(SignUpInputDTO input)
        {
            try
            {
                var  response = await _appService.SignUp(input);
                return Ok(response);
            }
            catch (Exception ex) 
            {
                return StatusCode(500,ex.Message);            
            }
        }

        // ---------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(SignInInputDTO input)
        {
            try
            {
                var response = await _appService.SignIn(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        // ---------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public async Task<IActionResult> Verification(VerificationInputDTO input)
        {
            try
            {
                var response = await _appService.Verification(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // ---------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public async Task<IActionResult> SendOTP(string email)
        {
            try
            {
                var response = await _appService.SendOTP(email);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        // ---------------------------------------------------------------------------------------

        [HttpPost("[action]")]
        public async Task<IActionResult> ResetPersonPassword(ResetPersonPasswordInputDTO input)
        {
            try
            {
                var response = await _appService.ResetPersonPassword(input);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // ---------------------------------------------------------------------------------------
        [HttpPost("[action]")]
        public async Task<IActionResult> SignOut(int useriD)
        {
            try
            {
                var response = await _appService.SignOut(useriD);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
