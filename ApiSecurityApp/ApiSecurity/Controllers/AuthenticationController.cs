using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiSecurity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
	private readonly IConfiguration _config;

	public AuthenticationController(IConfiguration config)
    {
		_config = config;
	}

    public record AuthenticationData(string? UserName, string? Password);
	public record UserData(int UserId, string UserName , string Title , string EmployeeId);

	// api/Authentication/token
	[HttpPost("token")]
	[AllowAnonymous]
	public ActionResult<string> Authenticate([FromBody] AuthenticationData data)
	{
		var user = ValidateCredentials(data);

        if (user is null)
        {
			return Unauthorized();
        }

		var token = GenerateToken(user);

		return Ok(token);
    }
	private string GenerateToken(UserData user)
	{
		var secretKey = new SymmetricSecurityKey
			(
			Encoding.ASCII.GetBytes(
				_config.GetValue<string>("Authentication:SecretKey")));

		var signingCredentials = new SigningCredentials(secretKey , SecurityAlgorithms.HmacSha256 );

		List<Claim> claims = new();
		claims.Add(new(JwtRegisteredClaimNames.Sub , user.UserId.ToString()));
		claims.Add(new(JwtRegisteredClaimNames.UniqueName , user.UserName));
		claims.Add(new("title" , user.Title));	
		claims.Add(new("EmployeeId" , user.EmployeeId ));	

		var token = new JwtSecurityToken(
			_config.GetValue<string>("Authentication:Issuer"),
			_config.GetValue<string>("Authentication:Audience"),
			claims,
			DateTime.Now, // When this token becomes valid
			DateTime.Now.AddDays(1), // when the token will expire
			signingCredentials
			);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}

	private UserData? ValidateCredentials(AuthenticationData data)
	{
		//THIS IS NOT PRODUCTION CODE - THIS IS ONLY A DEMO - DO NOT USE IN REAL LIFE // ok dude =/
		if (CompareValues(data.UserName, "Mobin") &&
			CompareValues(data.Password, "Test1234"))
		{
			return new UserData(1, data.UserName! , "Buisness Owner" , "E001" );
		}

		if (CompareValues(data.UserName, "sstorm") &&
			CompareValues(data.Password, "Test1234"))
		{
			return new UserData(2, data.UserName! , "Head of Security" , "E005");
		}

		return null;
	}
	private bool CompareValues(string? actual, string expected)
	{
		if (actual is not null)
		{
			if (actual.Equals(expected))
			{
				return true;
			}
		}
		return false;
	}
}

