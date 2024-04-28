using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public Role Role { get; set; }

        public List<Bar> Bars { get; set; }

        public List<Review> Reviews { get; set; }

        public User()
        {
                
        }

        public User(int id, string userName, string password, string firstName, string lastName, Role role, List<Bar> bars, List<Review> reviews)
        {
            Id = id;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Bars = bars;
            Reviews = reviews;
        }

        public User(int id, string userName, string password, string firstName, string lastName, Role role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
        }

        public User(string userName, string password, string firstName, string lastName, Role role, List<Bar> bars, List<Review> reviews)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            Bars = bars;
            Reviews = reviews;
        }
    }
}
