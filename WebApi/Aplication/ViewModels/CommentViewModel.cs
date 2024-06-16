namespace WebApi.Aplication.ViewModels
{
    public class CommentViewModel
    {
        public int Post_id { get; set; } // ID do post que o comentário está.
        public int User_id { get; set; } // ID do usuário que fez o comentário.
        public string Comment_content { get; set; } // Conteúdo do comentário.

        public string Date_comment { get; set; } // Data do comentário

    }
}
