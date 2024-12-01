using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Practice19.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int IsEmailVerified { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public User() { }
        public User(int id, string name, string email, int isEmailVerified, string password, string phone)
        {
            Id = id;
            Name = name;
            Email = email;
            IsEmailVerified = isEmailVerified;
            Password = password;
            Phone = phone;
        }
    }
}
