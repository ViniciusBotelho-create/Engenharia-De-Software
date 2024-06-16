namespace WebApi.Domain.Models
{
    public interface IPostInterface
    {
        public void Post(Post post);

        List<Post> GetPosts();

        Post? GetPost(int id);

        List<Post> GetPostsByUserId(int userId);

        public void DeletePost(int id);

        public void TogglePostSolvedStatus(int postId);
    }
}
