using AutoMapper;
using EcommerceAPI.Dtos;
using EcommerceAPI.Models;
namespace EcommerceAPI.Helpers;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>();
    }
}