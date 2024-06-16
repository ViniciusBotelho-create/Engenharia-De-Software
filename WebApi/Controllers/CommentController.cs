using Microsoft.AspNetCore.Mvc;
using WebApi.Aplication.ViewModels;
using WebApi.Domain.Models;
using WebApi.Infrastructure.Repositories;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/Comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentInterface _commentRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPostInterface _postRepository;

        public CommentController(ICommentInterface commentRepository, IUserRepository userRepository, IPostInterface postRepository)
        {
            _commentRepository = commentRepository ?? throw new ArgumentNullException(nameof(commentRepository));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        }

        [HttpPost]
        public IActionResult AddComment(CommentViewModel commentView)
        {
            // Verificar se o usuário existe
            var user = _userRepository.GetUser(commentView.User_id);
            if (user == null)
            {
                return BadRequest("O usuário não foi encontrado.");
            }

            // Verificar se o post existe
            var post = _postRepository.GetPost(commentView.Post_id);
            if (post == null)
            {
                return BadRequest("O post não foi encontrado.");
            }

            // Definindo a data e hora atual
            string currentDateTime = DateTime.Now.ToString();

            // Criando o objeto de comentário com os IDs do post e do usuário e a data e hora atuais
            var comment = new Comment(commentView.Post_id, commentView.User_id, commentView.Comment_content, currentDateTime);

            // Adicionando o comentário
            _commentRepository.AddComment(comment);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            var comment = _commentRepository.GetComment(id);
            if (comment == null)
            {
                return NotFound("Comentário não encontrado.");
            }

            _commentRepository.DeleteComment(id);

            return Ok("O comentário foi excluído com sucesso.");
        }

        [HttpPut("{id}")]
        public IActionResult EditComment(int id, CommentViewModel updatedComment)
        {
            var comment = _commentRepository.GetComment(id);
            if (comment == null)
            {
                return NotFound("Comentário não encontrado.");
            }

            comment.db_comment = updatedComment.Comment_content;
            comment.date_db_comment = updatedComment.Date_comment;

            _commentRepository.UpdateComment(comment);

            return Ok("O comentário foi atualizado com sucesso.");
        }

        [HttpGet("GetCommentsFromPost/{postId}")]
        public IActionResult GetCommentsFromPost(int postId)
        {
            // Verificar se o post existe
            var post = _postRepository.GetPost(postId);
            if (post == null)
            {
                return BadRequest("O post não foi encontrado.");
            }

            // Obter os comentários associados ao ID do post
            var comments = _commentRepository.GetCommentsByPostId(postId);

            return Ok(comments);
        }
    }
}
