using AutoMapper;
using EcommerceAPI.Dtos;
using EcommerceAPI.Infra;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Services
{
    public class UserServices : IUser
    {
        private readonly UserDbContext _context;
        public UserServices(UserDbContext context)
        {
            _context = context;
        }
        public async Task<User> Execute(UserDto userDto) 
        {
            var teste = await new UserValidator().ValidateAsync(userDto);

            var user = Mapper.ReferenceEquals();
            _context.User.Add(userDto);
            _context.SaveChanges();

            // validação com fluent validation (estudar como irá fazer pelo youtube)
            // chamar banco de dados e adicionar o usuário na tabela (estudar como fazer pelo youtube e no projeto já feito)
            // retornar o usuário criado
            return null;
        }

    }
}
