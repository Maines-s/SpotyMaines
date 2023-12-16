using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SpotyMaines.Application.AuthModule;
using SpotyMaines.Controllers.Shared;
using SpotyMaines.Domain.AutenticationModule;
using SpotyMaines.ViewModel.AuthModule;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SpotyMaines.Controllers.AuthModule
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly AuthService authService;
        private readonly IMapper mapper;

        public AuthController(AuthService authService, IMapper mapper)
        {
            this.authService = authService;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            var user = mapper.Map<User>(viewModel);

            var result = await authService.RegisterAsync(user, viewModel.PassWord);

            if (result.IsFailed)
                return BadRequest(result.Errors);

            var tokenViewModel = GenerateJwt(user, DateTime.Now.AddDays(1));

            return Ok(tokenViewModel);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel LoginVM)
        {
            var result = await authService.AuthenticateAsync(LoginVM.Login, LoginVM.PassWord);

            if(result.IsFailed)
                return BadRequest(result.Errors);

            var user = result.Value;

            var tokenViewModel = GenerateJwt(user, DateTime.Now.AddDays(1));

            return Ok(tokenViewModel);
        }
        public static TokenViewModel GenerateJwt(User user, DateTime date)
        {
            string keyToken = CreateKeyToken(user, date);

            var token = new TokenViewModel
            {
                Key = keyToken,
                ExpirationTime = date,
                UserVM = new UserTokenViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Login = user.UserName
                }
            };

            return token;
        }

        private static string CreateKeyToken(User user, DateTime date)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secreat = Encoding.ASCII.GetBytes("SegredoEAgendaMedica");

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = "eAgendaMedica",
                Audience = "http://localhost",
                Subject = ObterIdentityClaims(user),
                Expires = date,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secreat), SecurityAlgorithms.HmacSha256Signature)
            });

            string chaveToken = tokenHandler.WriteToken(token);

            return chaveToken;
        }

        private static ClaimsIdentity ObterIdentityClaims(User user)
        {
            var identityClaims = new ClaimsIdentity();

            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName));
            identityClaims.AddClaim(new Claim(JwtRegisteredClaimNames.GivenName, user.Name));

            return identityClaims;
        }
    }
}
