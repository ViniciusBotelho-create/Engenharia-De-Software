using System.Collections.Generic;
using WebApi.Domain.Models;

namespace WebApi.Domain.Models
{
    public interface ICommentInterface
    {
        void AddComment(Comment comment);
        void DeleteComment(int id);
        void UpdateComment(Comment comment);
        List<Comment> GetCommentsByPostId(int postId);
        Comment GetComment(int id);
    }
}

