using Microsoft.AspNetCore.Mvc;
using WebApi.Aplication.Services;
using WebApi.Domain.Models; // Adicione o namespace correto aqui
using WebApi.Infrastructure.Repositories;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/v1/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Auth(UserLoginViewModel userLogin)
        {
            // Verifica se o usuário existe no banco de dados
            var user = _userRepository.GetUserByEmail(userLogin.Email);

            if (user == null)
            {
                return Unauthorized(new { message = "Usuário não encontrado." });
            }

            // Verifica se a senha está correta
            if (user.password_user != userLogin.Password) 
            {
                return Unauthorized(new { message = "Senha incorreta." });
            }
            var token = TokenService.GenerateToken(user);
            return Ok(token);
        }
    }
}
