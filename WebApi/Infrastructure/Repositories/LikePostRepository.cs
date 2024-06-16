using System;
using System.Linq;
using WebApi.Domain.Models;

namespace WebApi.Infrastructure.Repositories
{
    public class LikePostRepository : ILikeInterface
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public int GetLikesCount(int postId)
        {
            return _context.likesPosts.Count(like => like.db_post_id == postId);
        }

        public bool HasLikedPost(int postId, int userId)
        {
            return _context.likesPosts.Any(like => like.db_post_id == postId && like.db_user_id == userId);
        }

        public void LikePost(LikesPost like)
        {
            _context.likesPosts.Add(like);
            _context.SaveChanges();
        }

        public void UnlikePost(int postId, int userId)
        {
            var like = _context.likesPosts.FirstOrDefault(l => l.db_post_id == postId && l.db_user_id == userId);
            if (like != null)
            {
                _context.likesPosts.Remove(like);
                _context.SaveChanges();
            }
        }
        public List<int> GetLikedUsers(int postId)
        {
            return _context.likesPosts
                .Where(like => like.db_post_id == postId)
                .Select(like => like.db_user_id)
                .ToList();
        }
    }
}
