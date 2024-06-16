using WebApi.Domain.Models;
using System.Linq;

namespace WebApi.Infrastructure.Repositories
{
    public class PostRepository : IPostInterface
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public List<Post> GetPosts()
        {
            return _context.Posts.ToList();
        }

        public Post? GetPost(int id)
        {
            return _context.Posts.Find(id);
        }

        public void Post(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
            // Se o post não for encontrado, nada é feito
        }

        public List<Post> GetPostsByUserId(int userId)
        {
            return _context.Posts.Where(post => post.db_user_id == userId).ToList();
        }

        public void TogglePostSolvedStatus(int postId)
        {
            var post = _context.Posts.Find(postId);
            if (post != null)
            {
                // Alternar o valor da propriedade solved_post
                post.solved_post = !post.solved_post;
                _context.SaveChanges();
            }
            // Se o post não for encontrado, nada é feito
        }

    }
}
