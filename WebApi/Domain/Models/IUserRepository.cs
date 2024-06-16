namespace WebApi.Domain.Models
{
    public interface IUserRepository
    {
        // Método para adicionar um usuário
        void AddUser(User user);

        // Método para obter um usuários
        List<User> GetUsers();
        User? GetUser(int id);

        User GetUserByEmail(string email);

        public void DeleteUserAndPosts(int userId);
    }

}
