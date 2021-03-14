using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinTutorials.Models
{
    public class Email
    {

        public string SenderInitial
        {
            get
            {
                var initials = SenderName.Split(' ');
                if (initials.Length == 1)
                {
                    return initials[0].ToUpper()[0].ToString();
                }
                else
                {
                    var char1 = initials[0].ToUpper()[0];
                    var char2 = initials[1].ToUpper()[0];
                    return char1.ToString() + char2.ToString();
                }
            }
        }

        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
