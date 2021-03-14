using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContactBook.Models;
using ContactBook.ViewModels;
using SQLite;
using Xamarin.Forms;

namespace ContactBook.Persistence
{
    public class SQLiteContactStore : IContactStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteContactStore()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
            _connection.CreateTableAsync<Contact>();
        }

        public Task AddContact(Contact contact)
        {
            return _connection.InsertAsync(contact);
        }

        public Task DeleteContact(Contact contact)
        {
            return _connection.DeleteAsync(contact);
        }

        public async Task<Contact> GetContact(int id)
        {
            return await _connection.GetAsync<Contact>(id);
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _connection.Table<Contact>().ToListAsync();
        }

        public Task UpdateContact(Contact contact)
        {
            return _connection.UpdateAsync(contact);
        }
    }
}
