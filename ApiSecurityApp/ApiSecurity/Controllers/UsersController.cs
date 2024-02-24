using ApiSecurity.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ApiSecurity.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
	private readonly IConfiguration _config;
    public UsersController(IConfiguration config)
    {
        _config = config;
    }

    // GET		    api/<UsersController>
    [HttpGet]
	public IEnumerable<string> Get()
	{
		return new string[] { "value1", "value2" };
	}

	// GET			https://localhost:7110/api/Users/5
	[HttpGet("{id}")]
	[Authorize(Policy = PolicyConstants.MustHaveEmployeeId)]
	public string Get(int id)
	{
		return _config.GetConnectionString("Default");
	}

	// POST          api/<UsersController>
	[HttpPost]
	public void Post([FromBody] string value)
	{
	}

	// PUT           api/<UsersController>/5
	[HttpPut("{id}")]
	public void Put(int id, [FromBody] string value)
	{
	}

	// DELETE		 api/<UsersController>/5
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
	}
}
