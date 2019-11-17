using System;
using System.IdentityModel.Tokens.Jwt;
using DanceCoolBusinessLogic.Helpers;
using DanceCoolBusinessLogic.Interfaces;
using DanceCoolDTO;
using DanceCoolWebApi.SignalR;
using DanceCoolWebApi.SignalR.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;

namespace DanceCoolWebApi.Controllers
{
	[Authorize]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IAuthenticationService _authenticationService;
		private readonly IUserService _userService;
        private readonly IHubContext<AuthenticatedHub, IAuthenticatedContract> _authenticatedHubContext;

        public AuthenticationController(IAuthenticationService authenticationService,
			IUserService userService, 
            IHubContext<AuthenticatedHub, IAuthenticatedContract> authenticatedHubContext)
		{
			this._authenticationService = authenticationService;
			this._userService = userService;
            _authenticatedHubContext = authenticatedHubContext;

        }

		[AllowAnonymous]
		[HttpPost]
		[Route("api/register")]
		public IActionResult Register([FromBody] RegistrationUserIdentityDto registrationCredentialsDto)
		{
			try
			{
				// save 
				var registeredUser = _authenticationService.RegisterUser(registrationCredentialsDto, registrationCredentialsDto.Password);

				var registeredCredentials =
					_authenticationService.Authenticate(registrationCredentialsDto.Email, registrationCredentialsDto.Password);
				var now = DateTime.UtcNow;

				// creating JWT-token
				var jwt = new JwtSecurityToken(
					issuer: AuthOptions.ISSUER,
					audience: AuthOptions.AUDIENCE,
					notBefore: now,
					claims: registeredCredentials.Claims,
					expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
					signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
						SecurityAlgorithms.HmacSha256));
				var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

				var response = new
				{
					accessToken = encodedJwt,
					tokenLifeTime = 3600000,
					userId = registeredUser.UserId
				};
                _authenticatedHubContext.Clients.All.UserRegistered(registeredUser.UserId);

                return Ok(response);
			}
			catch (AppException ex)
			{
				// return error message if there was an exception
				return BadRequest(new {message = ex.Message});
			}
		}

		[AllowAnonymous]
		[HttpPost("api/authorize")]
		public IActionResult Authorize([FromBody] AuthorizationUserIdentityDto authorizationCredentialsDto)
		{
			var credentials = _authenticationService.Authenticate(authorizationCredentialsDto.Email, authorizationCredentialsDto.Password);
			var user = _userService.GetUserByEmail(authorizationCredentialsDto.Email);

			if (credentials == null || user == null)
				return BadRequest(new {message = "Username or password is incorrect"});

			var now = DateTime.UtcNow;

			// creating JWT-token
			var jwt = new JwtSecurityToken(
				issuer: AuthOptions.ISSUER,
				audience: AuthOptions.AUDIENCE,
				notBefore: now,
				claims: credentials.Claims,
				expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
				signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
					SecurityAlgorithms.HmacSha256));
			var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

			var response = new
			{
				accessToken = encodedJwt,
				tokenLifeTime = 3600000,
				userId = user.Id
			};
            _authenticatedHubContext.Clients.All.UserAuthorized(user.Id);
            return Ok(response);
		}

        [AllowAnonymous]
        [HttpGet("api/log-out/{userId}")]
        public IActionResult LogOut(int userId)
        {
            _authenticatedHubContext.Clients.All.UserLoggedOut(userId);
            return Ok();
        }
    }
}