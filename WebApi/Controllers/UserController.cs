using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ViewModels;
using WebApi.Domain.Models;
using System;
using System.IO;
using WebApi.Infrastructure.Repositories;
using WebApi.Aplication.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPostInterface _postRepository;

        public UserController(IUserRepository userRepository, IPostInterface postRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }

        [HttpPost]
        public IActionResult Add([FromForm] UserViewModel userView)
        {
            // Verificar se já existe um usuário com o mesmo e-mail
            var existingUser = _userRepository.GetUserByEmail(userView.Email);
            if (existingUser != null)
            {
                return BadRequest("Um usuário com esse e-mail já existe.");
            }

            var filePath = Path.Combine("Storage", userView.PictureUrl.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            userView.PictureUrl.CopyTo(fileStream);

            var user = new User(
                userView.Name,
                userView.Email,
                userView.BirthDate,
                userView.Password,
                userView.City,
                userView.Address,
                userView.Phone,
                filePath,
                userView.CreationDate,
                userView.LikedPosts,
                userView.CommentedPosts
            );

            _userRepository.AddUser(user);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpPost]
        [Route("{id}/downloadPhoto")]
        public IActionResult DownlaodUserPhoto(int id)
        {
            User user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            if (string.IsNullOrEmpty(user.picture_user) || !System.IO.File.Exists(user.picture_user))
            {
                return NotFound("Foto do usuário não encontrada.");
            }

            byte[] dataBytes = System.IO.File.ReadAllBytes(user.picture_user);
            return File(dataBytes, "image/png");
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetUser(id);

            if (user == null)
            {
                return NotFound(); // Retorna 404 Not Found se o usuário não for encontrado
            }

            return Ok(user);
        }

        [HttpDelete]
        [Route("{userId}/DeleteUserAndPosts")]
        public IActionResult DeleteUserAndPosts(int userId)
        {
            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return BadRequest("O usuário não foi encontrado.");
            }

            // Excluir a foto do usuário da pasta "Storage"
            var userFilePath = user.picture_user;
            if (System.IO.File.Exists(userFilePath))
            {
                System.IO.File.Delete(userFilePath);
            }

            // Excluir os posts do usuário e suas fotos
            var userPosts = _postRepository.GetPostsByUserId(userId);
            foreach (var post in userPosts)
            {
                if (System.IO.File.Exists(post.picture_post))
                {
                    System.IO.File.Delete(post.picture_post);
                }
            }

            // Excluir o usuário e todos os seus posts
            _userRepository.DeleteUserAndPosts(userId);

            return Ok("Usuário, sua foto e todos os seus posts foram excluídos com sucesso.");
        }
    }
}
