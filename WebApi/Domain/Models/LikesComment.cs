using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Models
{
    [Table("db_likes_comments")]
    public class LikesComment
    {
        [Key]
        public int id { get; set; } // Chave primária autoincrementada para identificar cada like.
        public int db_comment_id { get; set; } // ID do post que está sendo curtido.
        public int db_user_id { get; set; } // ID do usuário que deu o like no post.
        public string? date_like { get; set; } // Data e hora em que o like foi dado.

        // Construtor da classe LikesPost
        public LikesComment(int commentId, int userId)
        {
            db_comment_id = commentId;
            db_user_id = userId;
            date_like = DateTime.Now.ToString(); // Define a data e hora do like como o momento atual.
        }

        // Construtor vazio necessário para o Entity Framework Core
        public LikesComment() { }
    }
}
