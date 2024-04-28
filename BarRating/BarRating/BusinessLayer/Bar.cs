using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Bar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        public List<User> Users { get; set; }
        public List<Review> Reviews { get; set; }


        public Bar()
        {
                
        }

        public Bar(int id, string name, string description, string image, List<User> users, List<Review> reviews)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
            Users = users;
            Reviews = reviews;
        }

        public Bar(int id, string name, string description, string image)
        {
            Id = id;
            Name = name;
            Description = description;
            Image = image;
        }

        public Bar(string name, string description, string image, List<User> users, List<Review> reviews)
        {
            Name = name;
            Description = description;
            Image = image;
            Users = users;
            Reviews = reviews;
        }
    }
}
