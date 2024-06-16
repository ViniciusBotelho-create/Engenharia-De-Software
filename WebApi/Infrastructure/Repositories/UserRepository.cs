using WebApi.Domain.Models;
using System.Linq;

namespace WebApi.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.email_user == email);
        }

        public void DeleteUserAndPosts(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                // Remove todos os posts associados ao usuário
                var userPosts = _context.Posts.Where(post => post.db_user_id == userId);
                _context.Posts.RemoveRange(userPosts);

                // Remove o usuário
                _context.Users.Remove(user);

                _context.SaveChanges();
            }
            // Se o usuário não for encontrado, nada é feito
        }
    }
}
