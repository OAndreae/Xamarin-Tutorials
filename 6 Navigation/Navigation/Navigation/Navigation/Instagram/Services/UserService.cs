using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Navigation.Instagram.Models;
using Navigation.Models;

namespace Navigation.Services
{
    public class UserService
    {
        private List<User> _users = new List<User>
        {
            new User
            {
                UserId = 1,
                Bio = "My name is Jenny Dalby",
                Name = "Jenny Dalby",
                Posts = new List<Post>
                {
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/nature" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/tech" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                }
            },
            new User
            {
                UserId = 2,
                Bio = "My name is Jonv",
                Name = "Jonv",
                Posts = new List<Post>
                {
                    new Post{ ImageUrl="https://placeimg.com/500/500/people/4" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/nature/1" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any/2" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch/6" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals/3" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch/8" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people/3" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals/7" },
                }},
            new User
            {
                UserId = 3,
                Bio = "My name is RachelMartin",
                Name = "RachelMartin",
                Posts = new List<Post>
                {
                    new Post{ ImageUrl="https://placeimg.com/500/500/people/3" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/nature/4" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/tech/5" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any/6" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people/7" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals/3" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch/9" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people/10" },
                }
            },
            new User
            {
                UserId = 4,
                Bio = "My name is Nivan Jay",
                Name = "Nivan Jay",
                Posts = new List<Post>
                {
                    new Post{ ImageUrl="https://placeimg.com/500/500/people/2" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/nature/7" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any/3" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/tech/5" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any/8" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people/9" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals/11" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any/2" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch/6" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people/7" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals/4" },
                }
            },
            new User
            {
                UserId = 5,
                Bio = "My name is SanazZ",
                Name = "SanazZ",
                Posts = new List<Post>
                {
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/nature" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/tech" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                }
            },
            new User
            {
                UserId = 6,
                Bio = "My name is NextLab",
                Name = "NextLab",
                Posts = new List<Post>
                {
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/nature" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/tech" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                }
            },
            new User
            {
                UserId = 7,
                Bio = "My name is Alex B",
                Name = "AlexB",
                Posts = new List<Post>
                {
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/nature" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/tech" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                }
            },
            new User
            {
                UserId = 8,
                Bio = "My name is Tara Chang",
                Name = "Tara Chang",
                Posts = new List<Post>
                {
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/nature" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/tech" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                }
            },
            new User
            {
                UserId = 9,
                Bio = "My name is TomK",
                Name = "Tom K",
                Posts = new List<Post>
                {
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/nature" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/tech" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/any" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/arch" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/people" },
                    new Post{ ImageUrl="https://placeimg.com/500/500/animals" },
                }
            }
        };

        public User GetUser(int userId)
        {
            return _users.SingleOrDefault(u => u.UserId == userId);
        }
    }
}
