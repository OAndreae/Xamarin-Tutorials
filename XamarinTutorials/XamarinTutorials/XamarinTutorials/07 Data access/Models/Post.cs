using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XamarinTutorials.Models
{
    public class Post : INotifyPropertyChanged
    {
        private string title;
        private string body;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        public string Title
        {
            get { return title; }
            set
            {
                if (title == value)
                    return;

                title = value;

                OnPropertyChanged();
            }

        }

        public string Body
        {
            get { return body; }
            set
            {
                if (body == value)
                    return;

                body = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
