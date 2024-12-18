using EcommerceAPI.Controllers;
using EcommerceAPI.Dtos;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IUser
    {
        public Task<User> Execute(UserDto userDto);
    }
}
