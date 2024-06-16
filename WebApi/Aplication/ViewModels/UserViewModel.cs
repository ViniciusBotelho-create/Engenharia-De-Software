namespace WebApi.Aplication.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }

        public string Password { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public IFormFile PictureUrl { get; set; } // URL da imagem do usuário para exibição na visualização

        public string CreationDate { get; set; }

        public int LikedPosts {  get; set; }

        public int CommentedPosts { get; set;}

    }


}

