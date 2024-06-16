using Microsoft.AspNetCore.Http;
using System;

namespace WebApi.Application.ViewModels
{
    public class PostViewModel
    {

        public int UserId { get; set; } // ID do usuário que fez o post.
        public string Title { get; set; } // Título do post.
        public string Content { get; set; } // Conteúdo do post.
        public string PostingDate { get; set; } // Data e hora de postagem do post.
        public IFormFile PictureUrl { get; set; } // Imagem do post em formato form

        public string Adress {  get; set; } // Endereço da ocorrência

        public bool Solved { get; set; } // Situação da ocorrência


    }
}
