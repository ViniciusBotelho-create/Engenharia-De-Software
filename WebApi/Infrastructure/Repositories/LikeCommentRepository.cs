using System;
using System.Linq;
using WebApi.Domain.Models;

namespace WebApi.Infrastructure.Repositories
{
    public class LikeCommentRepository : ILikeCommentsInterface
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public int GetLikesCount(int commentId)
        {
            return _context.likesComments.Count(like => like.db_comment_id == commentId);
        }

        public bool HasLikedComment(int postId, int userId)
        {
            return _context.likesComments.Any(like => like.db_comment_id == postId && like.db_user_id == userId);
        }

        public void LikeComment(LikesComment like)
        {
            _context.likesComments.Add(like);
            _context.SaveChanges();
        }

        public void UnlikeComment(int postId, int userId)
        {
            var like = _context.likesComments.FirstOrDefault(l => l.db_comment_id == postId && l.db_user_id == userId);
            if (like != null)
            {
                _context.likesComments.Remove(like);
                _context.SaveChanges();
            }
        }
        public List<int> GetLikedUsers(int postId)
        {
            return _context.likesComments
                .Where(like => like.db_comment_id == postId)
                .Select(like => like.db_user_id)
                .ToList();
        }
    }
}
