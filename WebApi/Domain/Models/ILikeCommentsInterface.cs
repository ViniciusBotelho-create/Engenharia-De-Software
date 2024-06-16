namespace WebApi.Domain.Models
{
    public interface ILikeCommentsInterface
    {
        void LikeComment(LikesComment like); // Método para adicionar um like em um post
        void UnlikeComment(int commentID, int userID); // Método para remover um like de um post
        bool HasLikedComment(int CommentID, int userId); // Método para verificar se um usuário deu like em um post
        int GetLikesCount(int CommentID); // Método para obter o número de likes de um post

        public List<int> GetLikedUsers(int postId);
    }
}
