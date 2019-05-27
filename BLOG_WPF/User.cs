using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_WPF
{
    public enum Right
    {
        ADMIN,
        USER,
        GUEST
    }

    [Table("USERS")]
    public class User
    {
        public User()
        {
        }

        public User(string pseudo, string password, Right right = Right.GUEST)
        {
            Pseudo = pseudo;
            Password = password;
            Right = right;
            if (Pseudo == "ADMIN" && Password == "ADMIN")
            {
                Right =  Right.ADMIN;
            }
        }

        [Key]
        public int Id { get; set; }

        [Column("Pseudo")]
        public string Pseudo { get; set; }
        [Column("Password")]
        public string Password { get; set; }

        [Column("Right")]
        public Right Right { get; set; }

    }
}
