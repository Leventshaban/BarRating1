using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int User_Id { get; set; }
        [Required]
        [ForeignKey("Bar")]
        public int Bar_Id { get; set; }
        [Required]
        public string Text { get; set; }
        public User User { get; set; }
        public Bar Bar { get; set; }
        public Review()
        {
                
        }

        public Review(int id, int user_Id, int bar_Id, string text, User user, Bar bar)
        {
            Id = id;
            User_Id = user_Id;
            Bar_Id = bar_Id;
            Text = text;
            User = user;
            Bar = bar;
        }

        public Review(int user_Id, int bar_Id, string text, User user, Bar bar)
        {
            User_Id = user_Id;
            Bar_Id = bar_Id;
            Text = text;
            User = user;
            Bar = bar;
        }
    }
}
