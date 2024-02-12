using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cine.Contracts.Authentication;
using Cine.Application.Services.Authentication;
namespace Cine.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authRequest = _authenticationService.Register(request.FirstName,
                                                              request.LastName,
                                                              request.Email,
                                                              request.Password); 

            var response = new AuthenticationResponse(authRequest.ID,
                                                      authRequest.Firstname,
                                                      authRequest.Lastname,
                                                      authRequest.Email,
                                                      authRequest.Points,
                                                      authRequest.Token);                                                                 
            return Ok(response);
        }
        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authRequest = _authenticationService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse(authRequest.ID,
                                                      authRequest.Firstname,
                                                      authRequest.Lastname,
                                                      authRequest.Email,
                                                      authRequest.Points,
                                                      authRequest.Token);
            return Ok(response);
        }
    }
}