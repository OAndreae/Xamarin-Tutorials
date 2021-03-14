using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTutorials.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string Status { get; set; }
        public string ImageUrl { get; set; }
    }
}
