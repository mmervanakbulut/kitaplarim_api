using kitaplarim_api.Data;
using kitaplarim_api.DTOs.UserDTOs;
using kitaplarim_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace kitaplarim_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController(AppDbContext context, IConfiguration configuration) : ControllerBase
	{
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] UserCreateDto request)
		{
			var emailToSave = request.Email.ToLower();

			if (await context.Users.AnyAsync(u => u.Email == emailToSave))
			{
				return BadRequest("Email already exists.");
			}

			var user = new User
			{
				Nickname = request.Nickname,
				Email = emailToSave
			};

			// password hashing
			var passwordHasher = new PasswordHasher<User>();
			user.HashedPassword = passwordHasher.HashPassword(user, request.Password);

			context.Users.Add(user);
			await context.SaveChangesAsync();

			return Ok("User registered successfully.");
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] UserLoginDto request)
		{ 
			var emailToLogin = request.Email.ToLower();
			var user = await context.Users.FirstOrDefaultAsync(u => u.Email == emailToLogin);

			if (user == null)
			{
				return Unauthorized("Invalid email or password.");
			}

			// password verification with password hasher
			var passwordHasher = new PasswordHasher<User>();
			var verificationResult = passwordHasher.VerifyHashedPassword(user, user.HashedPassword!, request.Password);

			if (verificationResult == PasswordVerificationResult.Failed)
			{
				return Unauthorized("Invalid email or password.");
			}

			// Generate JWT token and expire time
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!);

			var expirationTime = DateTime.UtcNow.AddHours(1);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					new Claim(ClaimTypes.Email, user.Email),
				}),
				Expires = expirationTime,
				Issuer = configuration["Jwt:Issuer"],
				Audience = configuration["Jwt:Audience"],
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			var jwt = tokenHandler.WriteToken(token);

			// creating cookie and sending token in cookie
			var cookieOptions = new CookieOptions
			{
				HttpOnly = true,
				Secure = true,
				SameSite = SameSiteMode.Strict,
				Expires = expirationTime
			};

			Response.Cookies.Append("AuthToken", jwt, cookieOptions);

			return Ok("User logged in successfully.");
		}

		[HttpPost("logout")]
		public IActionResult Logout()
		{
			Response.Cookies.Delete("AuthToken");
			return Ok("User logged out successfully.");
		}
	}
}
