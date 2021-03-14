using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Navigation.Instagram.Models;

namespace Navigation.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ImageUrl
        {
            get
            {
                return string.Format("https://placeimg.com/100/100/people/{0}", UserId);
            }
        }
        public IEnumerable<Post> Posts { get; set; }
    }
}
