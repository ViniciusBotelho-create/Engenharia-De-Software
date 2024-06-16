using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace WebApi.Domain.Models
{

    [Table("db_comment")]
    public class Comment
    {
        [Key]
        // Propriedades correspondentes aos campos da tabela db_comment
        public int id { get; private set; } // Chave primária autoincrementada para identificar cada post.
        public int db_post_id { get; private set; } // ID do post que o comentário está.
        public int db_user_id { get; private set; } // ID do usuário que fez o comentário.
        public string db_comment { get; set; } // Conteúdo do comentário.
        public string date_db_comment { get; set; } // Data do comentário
        
    
        public Comment( int post_id, int user_id, string content, string comment_Date)
        {
            db_post_id = post_id; 
            db_user_id = user_id; 
            db_comment = content;   
            date_db_comment = comment_Date;
        }
        public Comment() { }
        
    }
}
