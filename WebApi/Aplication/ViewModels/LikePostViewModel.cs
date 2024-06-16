using System;

namespace WebApi.Application.ViewModels
{
    public class LikePostViewModel
    {
        public int PostId { get; set; } // ID do post que está recebendo o like.
        public int UserId { get; set; } // ID do usuário que está dando o like.
    }
}
