using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ContactBook.Models
{
    public class Contact : INotifyPropertyChanged
    {
        private string _firstName;
        private string _surname;

        public int Id { get; set; }
        public string FullName
        {
            get { return FirstName + " " + Surname; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName == value)
                    return;
                _firstName = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname == value)
                    return;
                _surname = value;
                OnPropertyChanged();
                OnPropertyChanged("FullName");
            }
        }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
