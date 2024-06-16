using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ViewModels;
using WebApi.Domain.Models;
using System;
using WebApi.Infrastructure.Repositories;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/LikeComment")]
    public class LikeCommentsController : ControllerBase
    {
        private readonly ILikeCommentsInterface _likeCommentsRepository;

        public LikeCommentsController(ILikeCommentsInterface likeCommentsRepository)
        {
            _likeCommentsRepository = likeCommentsRepository ?? throw new ArgumentNullException(nameof(likeCommentsRepository));
        }

        [HttpPost]
        public IActionResult LikeComment(LikeCommentViewModel like)
        {
            try
            {
                // Verifica se o usuário já curtiu o comentario antes de adicionar o like
                if (_likeCommentsRepository.HasLikedComment(like.CommentId, like.UserId))
                {
                    return BadRequest("O usuário já curtiu este comentário.");
                }

                // Adiciona o like apenas se o usuário ainda não curtiu o comentario
                _likeCommentsRepository.LikeComment(new LikesComment(like.CommentId, like.UserId));
                return Ok("Like adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                // Captura a exceção interna para obter mais detalhes
                var innerExceptionMessage = ex.InnerException?.Message ?? "Detalhes indisponíveis";
                return BadRequest($"Erro ao adicionar like: {innerExceptionMessage}");
            }
        }

        [HttpDelete("{commentID}/{userId}")]
        public IActionResult UnlikeComment(int commentID, int userId)
        {
            try
            {
                // Verificar se o usuário realmente curtiu o comentário antes de tentar remover o like
                if (!_likeCommentsRepository.HasLikedComment(commentID, userId))
                {
                    return BadRequest("O usuário ainda não curtiu este comentário.");
                }

                _likeCommentsRepository.UnlikeComment(commentID, userId);
                return Ok("Like removido com sucesso.");
            }
            catch (Exception ex)
            {
                // Capturar a exceção interna para obter mais detalhes
                var innerExceptionMessage = ex.InnerException?.Message ?? "Detalhes indisponíveis";
                return BadRequest($"Erro ao remover like: {innerExceptionMessage}");
            }
        }

        [HttpGet("{commentID}/LikesCount")]
        public IActionResult GetLikesCount(int commentID)
        {
            try
            {
                int likesCount = _likeCommentsRepository.GetLikesCount(commentID);
                return Ok(likesCount);
            }
            catch (Exception ex)
            {
                // Capturar a exceção interna para obter mais detalhes
                var innerExceptionMessage = ex.InnerException?.Message ?? "Detalhes indisponíveis";
                return BadRequest($"Erro ao obter contagem de likes: {innerExceptionMessage}");
            }
        }

        [HttpGet("{commentID}/HasLikedComment/{userId}")]
        public IActionResult HasLikedComment(int commentID, int userId)
        {
            try
            {
                bool hasLiked = _likeCommentsRepository.HasLikedComment(commentID, userId);
                return Ok(hasLiked);
            }
            catch (Exception ex)
            {
                // Capturar a exceção interna para obter mais detalhes
                var innerExceptionMessage = ex.InnerException?.Message ?? "Detalhes indisponíveis";
                return BadRequest($"Erro ao verificar se o usuário de ID {userId} curtiu o comentário de ID {commentID}: {innerExceptionMessage}");
            }
        }

        [HttpGet("{commentID}/LikedUsers")]
        public IActionResult GetLikedUsers(int commentID)
        {
            try
            {
                var likedUsers = _likeCommentsRepository.GetLikedUsers(commentID);
                return Ok(likedUsers);
            }
            catch (Exception ex)
            {
                // Captura a exceção interna para obter mais detalhes
                var innerExceptionMessage = ex.InnerException?.Message ?? "Detalhes indisponíveis";
                return BadRequest($"Erro ao obter usuários que curtiram o comentário: {innerExceptionMessage}");
            }
        }
    }
}
