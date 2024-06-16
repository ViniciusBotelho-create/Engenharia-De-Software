using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain.Models
{
    [Table("db_user")]
    public class User
    {
        [Key]
        public int id { get; private set; }
        public string name_user { get; private set; }
        public string email_user { get; private set; }
        public string password_user { get; private set; }
        public string birthdate_user { get; private set; }
        public string city_user { get; private set; }
        public string address_user { get; private set; }
        public string phone_user { get; private set; }
        public string? picture_user { get; private set; }
        public string criationdate_user { get; private set; }

        public int likedposts_user { get; private set; }

        public int commentedposts_user { get; private set; }

        // Construtor sem parâmetros exigido pelo Entity Framework
        public User() { }

        // Construtor da classe User
        public User(string name, string email, string password, string birthDate, string city, string address, string phone, string picture, string creationDate, int likedposts, int commentedposts)
        {
            name_user = name ?? throw new ArgumentNullException(nameof(name));
            email_user = email;
            password_user = password;
            birthdate_user = birthDate;
            city_user = city;
            address_user = address;
            phone_user = phone;
            picture_user = picture;
            criationdate_user = creationDate;
            likedposts_user = likedposts;
            commentedposts_user = commentedposts;
        }
    }
}
