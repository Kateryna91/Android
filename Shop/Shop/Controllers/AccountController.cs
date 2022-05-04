using Shop.Data;
using Shop.Data.Entities.Identity;
using Shop.Helpers;
using Shop.Models;
using Shop.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Imaging;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppEFContext _context;
        public AccountController(UserManager<AppUser> userManager,
            IJwtTokenService jwtTokenService, IMapper mapper,
            AppEFContext context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _jwtTokenService = jwtTokenService;
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            var img = ImageWorker.FromBase64StringToImage(model.Photo);
            string randomFilename = Path.GetRandomFileName() + ".jpeg";
            var dir = Path.Combine(Directory.GetCurrentDirectory(), "uploads", randomFilename);
            img.Save(dir, ImageFormat.Jpeg);
            var user = _mapper.Map<AppUser>(model);
            user.Photo = randomFilename;
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(new { errors = result.Errors });


            return Ok(new { token = _jwtTokenService.CreateToken(user) });
        }

        [HttpGet]

        [Route("users")]
        public async Task<IActionResult> Users()
        {
            Thread.Sleep(2000);
            var list = await _context.Users.Select(x => _mapper.Map<UserItemViewModel>(x))
                .AsQueryable().ToListAsync();

            return Ok(list);
        }
        /// <summary>
        /// Вхід на сайт
        /// </summary>
        /// <param name="model">Подель із даними</param>
        /// <returns>Повертає токен авторизації</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Login user</response>
        /// <response code="400">Login has missing/invalid values</response>
        /// <response code="500">Oops! Can't create your login right now</response>
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TokenResponceViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {

                    if (await _userManager.CheckPasswordAsync(user, model.Password))
                    {
                        return Ok(new TokenResponceViewModel { token = _jwtTokenService.CreateToken(user) });
                    }
                }
                return BadRequest(new { error = "Користувача не знайдено" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Помилка на сервері. " + ex.Message });
            }
        }
    }
}
