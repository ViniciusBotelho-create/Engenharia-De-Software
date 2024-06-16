using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Models
{
    [Table("db_likes")]
    public class LikesPost
    {
        [Key]
        public int id { get; set; } // Chave primária autoincrementada para identificar cada like.

        public int db_user_id { get; set; } // ID do usuário que deu o like no post.
        public int db_post_id { get; set; } // ID do post que está sendo curtido.

        public string? date_like { get; set; } // Data e hora em que o like foi dado.

        // Construtor da classe LikesPost
        public LikesPost(int postId, int userId)
        {
            db_post_id = postId;
            db_user_id = userId;
            date_like = DateTime.Now.ToString(); // Define a data e hora do like como o momento atual.
        }

        // Construtor vazio necessário para o Entity Framework Core
        public LikesPost() { }
    }
}
