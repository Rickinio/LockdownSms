using LockdownSms.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LockdownSms.Services
{
    public class UserDatabase : IDataStore<User>
    {
        private readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        public async Task<int> AddItemAsync(User user)
        {
            return await _database.InsertAsync(user);
        }

        public async Task<int> UpdateItemAsync(User user)
        {
            return await _database.UpdateAsync(user);
        }

        public async Task<int> DeleteItemAsync(User user)
        {
            return await _database.DeleteAsync(user);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await _database.Table<User>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await _database.Table<User>().ToListAsync();
        }
    }
}
