using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiSecurity.Constants;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(opts =>
{
	opts.AddPolicy(PolicyConstants.MustHaveEmployeeId, policy =>
	{
		policy.RequireClaim("employeeId");
	});
	opts.AddPolicy(PolicyConstants.MustBeTheOwner, policy =>
	{
		policy.RequireUserName("Mobin");
		policy.RequireClaim("title", "Buisness Owner");
	});
	opts.AddPolicy(PolicyConstants.MustBeAVeteranEmployee, policy =>
	{
		policy.RequireUserName("Mobin");
		policy.RequireClaim("title", "Buisness Owner");
	});
	opts.FallbackPolicy = new AuthorizationPolicyBuilder()
	.RequireAuthenticatedUser()
	.Build();
});
builder.Services.AddAuthentication("Bearer")
	.AddJwtBearer(opts =>
	{
		opts.Events = new JwtBearerEvents
		{
			OnAuthenticationFailed = e =>
			{
				var Resault = e.Exception.GetType();
				return Task.CompletedTask;
			}
			
		};
		
		opts.TokenValidationParameters = new()
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateIssuerSigningKey = false,
			ValidateLifetime = true,
			ValidIssuer = builder.Configuration.GetValue<string>("Authentication:Issuer"),
			ValidAudience = builder.Configuration.GetValue<string>("Authentication:Audience"),
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
				builder.Configuration.GetValue<string>("Authentication:SecretKey"))),
			ClockSkew = TimeSpan.Zero
		};
		opts.IncludeErrorDetails  = true;
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
