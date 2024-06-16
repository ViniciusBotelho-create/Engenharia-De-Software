using Microsoft.AspNetCore.Mvc;
using WebApi.Application.ViewModels;
using WebApi.Domain.Models;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/LikePosts")]
    public class LikePostsController : ControllerBase
    {
        private readonly ILikeInterface _likeRepository;

        public LikePostsController(ILikeInterface likeRepository)
        {
            _likeRepository = likeRepository ?? throw new ArgumentNullException(nameof(likeRepository));
        }

        [HttpPost]
        public IActionResult LikePost(LikePostViewModel like)
        {
            try
            {
                // Verifica se o usuário já curtiu o post antes de adicionar o like
                if (_likeRepository.HasLikedPost(like.PostId, like.UserId))
                {
                    return BadRequest("O usuário já curtiu este post.");
                }

                // Adiciona o like apenas se o usuário ainda não curtiu o post
                _likeRepository.LikePost(new LikesPost(like.PostId, like.UserId));
                return Ok("Like adicionado com sucesso.");
            }
            catch (Exception ex)
            {
                // Captura a exceção interna para obter mais detalhes
                return BadRequest($"Erro ao adicionar like: {ex}");
            }
        }

        [HttpDelete("{postId}/{userId}")]
        public IActionResult UnlikePost(int postId, int userId)
        {
            try
            {
                // Verificar se o usuário realmente curtiu o post antes de tentar remover o like
                if (!_likeRepository.HasLikedPost(postId, userId))
                {
                    return BadRequest("O usuário ainda não curtiu este post.");
                }

                _likeRepository.UnlikePost(postId, userId);
                return Ok("Like removido com sucesso.");
            }
            catch (Exception ex)
            {
                // Capturar a exceção interna para obter mais detalhes
                var innerExceptionMessage = ex.InnerException?.Message ?? "Detalhes indisponíveis";
                return BadRequest($"Erro ao remover like: {innerExceptionMessage}");
            }
        }

        [HttpGet("{postId}/LikesCount")]
        public IActionResult GetLikesCount(int postId)
        {
            try
            {
                int likesCount = _likeRepository.GetLikesCount(postId);
                return Ok(likesCount);
            }
            catch (Exception ex)
            {
                // Capturar a exceção interna para obter mais detalhes
                var innerExceptionMessage = ex.InnerException?.Message ?? "Detalhes indisponíveis";
                return BadRequest($"Erro ao obter contagem de likes: {innerExceptionMessage}");
            }
        }

        [HttpGet("{postId}/HasLikedPost/{userId}")]
        public IActionResult HasLikedPost(int postId, int userId)
        {
            try
            {
                bool hasLiked = _likeRepository.HasLikedPost(postId, userId);
                return Ok(hasLiked);
            }
            catch (Exception ex)
            {
                // Capturar a exceção interna para obter mais detalhes
                var innerExceptionMessage = ex.InnerException?.Message ?? "Detalhes indisponíveis";
                return BadRequest($"Erro ao verificar se o usuário de ID {userId} curtiu o post de ID {postId}: {innerExceptionMessage}");
            }
        }

        [HttpGet("{postId}/LikedUsers")]
        public IActionResult GetLikedUsers(int postId)
        {
            try
            {
                var likedUsers = _likeRepository.GetLikedUsers(postId);
                return Ok(likedUsers);
            }
            catch (Exception ex)
            {
                // Captura a exceção interna para obter mais detalhes
                var innerExceptionMessage = ex.InnerException?.Message ?? "Detalhes indisponíveis";
                return BadRequest($"Erro ao obter usuários que curtiram o post: {innerExceptionMessage}");
            }
        }
    }
}
