using AutoMapper;
using EcommerceAPI.Dtos;
using EcommerceAPI.Infra;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IUser _user;

        public UserController(UserDbContext context, IUser user)
        {
            _context = context;
            _user = user;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _context.User.ToList();
            var config = new MapperConfiguration(static cfg => cfg.CreateMap<UserServices, UserDto>());
            var mapper = new Mapper(config);
            var user = mapper.Map<User>(users);
            return Ok(users);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        [HttpPost("CriarUsuario")]
        public async Task<IActionResult> CriarUsuario(UserDto userDto)
        {

            var response = await _user.Execute(userDto);
            return Ok(response);
        }
    }


}



