using System.Collections.Generic;
using System.Linq;
using WebApi.Domain.Models;

namespace WebApi.Infrastructure.Repositories
{
    public class CommentRepository : ICommentInterface
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void DeleteComment(int id)
        {
            var comment = _context.Comments.Find(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                _context.SaveChanges();
            }
            // Se o comentário não for encontrado, nada é feito
        }

        public void UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetCommentsByPostId(int postId)
        {
            return _context.Comments.Where(comment => comment.db_post_id == postId).ToList();
        }

        public Comment GetComment(int id)
        {
            return _context.Comments.Find(id);
        }
    }
}
