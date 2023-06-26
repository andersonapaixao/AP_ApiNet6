using AP_ApiNet6.Application.DTOs;
using AP_ApiNet6.Application.DTOs.Validations;
using AP_ApiNet6.Application.Services.Interfaces;
using AP_ApiNet6.Domain.Authentication;
using AP_ApiNet6.Domain.Entities;
using AP_ApiNet6.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_ApiNet6.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<dynamic>("Objeto deve ser informado!");

            var validator = new UserDTOValidator().Validate(userDTO);
            if (!validator.IsValid)
                return ResultService.RequestError<dynamic>("Problemas de validade!", validator);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDTO.Email, userDTO.Password);
            if (user == null)
                return ResultService.Fail<dynamic>("Usuário ou senhao não encontrado!");

            return ResultService.Ok(_tokenGenerator.Generator(user));
        }
    }
}
