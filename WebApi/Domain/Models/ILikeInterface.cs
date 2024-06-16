namespace WebApi.Domain.Models
{
    public interface ILikeInterface
    {
        void LikePost(LikesPost like); // Método para adicionar um like em um post
        void UnlikePost(int postId, int userId); // Método para remover um like de um post
        bool HasLikedPost(int postId, int userId); // Método para verificar se um usuário deu like em um post
        int GetLikesCount(int postId); // Método para obter o número de likes de um post

        public List<int> GetLikedUsers(int postId);
    }
}
