using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Models
{
    [Table("db_post")]
    public class Post
    {
        [Key]
        // Propriedades correspondentes aos campos da tabela dB_post
        public int id { get; private set; } // Chave primária autoincrementada para identificar cada post.
        public int db_user_id { get; private set; } // ID do usuário que fez o post.
        public string title_post { get; private set; } // Título do post.
        public string content_post { get; private set; } // Conteúdo do post.
        public string postingdate_post { get; private set; } // Data e hora de postagem do post.
        public string picture_post { get; private set; } // Imagem do post em formato string
        
        public string adress_post { get; private set; } // Endereço da ocorrência da postagem

        public bool solved_post { get; set; } // situação da ocorrência da postagem



        // Construtor da classe Post
        public Post(int dBUserId, string title, string content, string postingDate, string picture, string adress, bool solved)
        {
            db_user_id = dBUserId;
            title_post = title ?? throw new ArgumentNullException(nameof(title));
            content_post = content ?? throw new ArgumentNullException(nameof(content));
            postingdate_post = postingDate;
            picture_post = picture;
            adress_post = adress;
            solved_post = solved;

        }

        public Post() { }
    }
}

