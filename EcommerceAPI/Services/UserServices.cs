using AutoMapper;
using EcommerceAPI.Dtos;
using EcommerceAPI.Infra;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Validation;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Services
{
    public class UserServices : IUser
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;

        public UserServices(UserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            var users = await _context.User.ToListAsync();
            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<User> Execute(UserDto userDto)
        {
            // Validação do DTO usando FluentValidation
            var validationResult = await new UserValidator().ValidateAsync(userDto);
            if (!validationResult.IsValid)
            {
                // Tratar erros de validação
                throw new Exception(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
            }

            // Mapeia UserDto para a entidade User
            var user = _mapper.Map<User>(userDto);

            // Adiciona o usuário ao banco de dados
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();

            // Retorna o usuário criado
            return user;
        }
    }
}
