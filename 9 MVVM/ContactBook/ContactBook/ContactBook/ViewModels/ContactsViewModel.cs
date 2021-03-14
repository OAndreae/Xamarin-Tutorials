﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ContactBook.Models;
using Xamarin.Forms;

namespace ContactBook.ViewModels
{
    public class ContactsViewModel : ViewModelBase
    {
        private readonly IPageService _pageService;
        private readonly IContactStore _contactStore;

        private ObservableCollection<ContactViewModel> _contacts;
        private ContactViewModel _selectedContact;

        private bool _isDataLoaded = false;

        public ICommand AddContactCommand { get; private set; }
        public ICommand ViewContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }

        public ObservableCollection<ContactViewModel> Contacts
        {
            get { return _contacts; }
            private set { SetProperty(ref _contacts, value); }
        }

        public ContactViewModel SelectedContact
        {
            get { return _selectedContact; }
            set { SetProperty(ref _selectedContact, value); }
        }

        public ContactsViewModel(IPageService pageService, IContactStore contactStore)
        {
            _pageService = pageService;
            _contactStore = contactStore;

            AddContactCommand = new Command(AddContact);
            ViewContactCommand = new Command<ContactViewModel>(c => ViewContact(c));
            DeleteContactCommand = new Command<ContactViewModel>(c => DeleteContact(c));
        }

        public async void LoadContacts()
        {
            if (_isDataLoaded)
                return;

            var contacts = await _contactStore.GetContacts();
            _isDataLoaded = true;
            
            Contacts = new ObservableCollection<ContactViewModel>();
            foreach (var c in contacts)
                Contacts.Add(new ContactViewModel(c));
            OnPropertyChanged(nameof(Contacts));
        }

        private async void AddContact()
        {
            var contact = new ContactViewModel();
            var viewModel = new ContactsDetailViewModel(contact, _pageService, _contactStore);
            // Regsiter event handler before navigation to prevent a null exception
            viewModel.ContactAdded += (source, c) =>
            {
                Contacts.Add(new ContactViewModel(c));
            };

            await _pageService.PushAsync(new ContactsDetailPage(viewModel));
        }

        private void ViewContact(ContactViewModel contact)
        {
            if (contact == null)
                return;

            SelectedContact = null;

            var contactsDetailVM = new ContactsDetailViewModel(contact, _pageService, _contactStore);
            // Regsiter event handler before navigation to prevent a null exception
            contactsDetailVM.ContactUpdated += (source, updatedContact) =>
            {
                contact.FirstName = updatedContact.FirstName;
                contact.Surname = updatedContact.Surname;
                contact.PhoneNumber = updatedContact.PhoneNumber;
                contact.IsBlocked = updatedContact.IsBlocked;
            };

            _pageService.PushAsync(new ContactsDetailPage(contactsDetailVM));
        }

        private async void DeleteContact(ContactViewModel contactViewModel)
        {
            if(await _pageService.DisplayAlert("Delete contact", $"Are you sure that you want to delete {contactViewModel.FullName} from your contacts?", "Yes", "Cancel"))
            {
                Contacts.Remove(contactViewModel);
                var contact = await _contactStore.GetContact(contactViewModel.Id);
                await _contactStore.DeleteContact(contact);
            }
        }
    }
}
