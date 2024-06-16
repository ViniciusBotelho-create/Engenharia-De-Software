using WebApi.Domain.Models;
using WebApi.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApi.Application.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/Post")]
    public class PostController : ControllerBase
    {
        private readonly IPostInterface _postRepository;
        private readonly IUserRepository _userRepository;

        public PostController(IPostInterface postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpPost]
        public IActionResult Add(PostViewModel postView)
        {
            // Verificar se o usuário associado ao post existe na tabela db_user
            var user = _userRepository.GetUser(postView.UserId);
            if (user == null)
            {
                return BadRequest("O usuário associado ao post não existe na tabela db_user.");
            }

            // Obter o ID do usuário correto
            int userId = user.id;

            var filePath = Path.Combine("Storage", postView.PictureUrl.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            postView.PictureUrl.CopyTo(fileStream);

            // Criar o objeto Post
            var post = new Post(userId, postView.Title, postView.Content, postView.PostingDate, filePath, postView.Adress, postView.Solved);

            // Adicionar o post
            _postRepository.Post(post);

            return Ok();
        }
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _postRepository.GetPosts();
            return Ok(posts);
        }

        [HttpGet]
        [Route("GetPostsByUserId/{userId}")]
        public IActionResult GetPostsByUserId(int userId)
        {
            // Verificar se o usuário existe
            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return BadRequest("O usuário não foi encontrado.");
            }

            // Obter posts associados ao ID do usuário
            var posts = _postRepository.GetPostsByUserId(userId);

            return Ok(posts);
        }

        [HttpPost]
        [Route("{id}/downloadPhoto")]
        public IActionResult DownloadPostPhoto(int id)
        {
            var post = _postRepository.GetPost(id);
            if (post == null)
            {
                return NotFound("Post não encontrado.");
            }

            if (string.IsNullOrEmpty(post.picture_post) || !System.IO.File.Exists(post.picture_post))
            {
                return NotFound("Foto do post não encontrada.");
            }

            var dataBytes = System.IO.File.ReadAllBytes(post.picture_post);
            return File(dataBytes, "image/png");
        }


        [HttpDelete]
        [Route("{id}/DeletePost")]
        public IActionResult DeletePostById(int id)
        {
            var post = _postRepository.GetPost(id);
            if (post == null)
            {
                return BadRequest("O post não foi encontrado.");
            }

            _postRepository.DeletePost(id);

            return Ok("O post foi excluído com sucesso.");
        }

        [HttpPut]
        [Route("{id}/ToggleSolved")]
        public IActionResult ToggleSolvedStatus(int id)
        {
            var post = _postRepository.GetPost(id);
            if (post == null)
            {
                return NotFound("Post não encontrado.");
            }

            _postRepository.TogglePostSolvedStatus(id);

            return Ok("O status de resolução do post foi alterado com sucesso.");
        }



    }
}
