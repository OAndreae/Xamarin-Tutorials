using System;
using System.Collections.Generic;
using System.Text;
using ContactBook.Models;

namespace ContactBook.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsBlocked { get; set; }

        public ContactViewModel() {}

        public ContactViewModel(Contact contact)
        {
            Id = contact.Id;
            _firstName = contact.FirstName;
            _surname = contact.Surname;
            PhoneNumber = contact.PhoneNumber;
            Email = contact.Email;
            IsBlocked = contact.IsBlocked;
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
                OnPropertyChanged("FullName");
            }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                SetProperty(ref _surname, value);
                OnPropertyChanged("FullName");
            }
        }

        public string FullName
        {
            get { return $"{FirstName} {Surname}"; }
        }
    }
}
