using LockdownSms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockdownSms.Services
{
    public class MockUserDataStore
    {
        List<User> users = new List<User>();

        public MockUserDataStore()
        {
            //users = new List<User>()
            //{
            //    new User {
            //        Id = Guid.NewGuid().ToString(),
            //        FirstName = "Ricky",
            //        LastName = "Stam",
            //        Address = "Petrou Adipa 22 Xalandri"}
            //};
        }

        public async Task<bool> AddItemAsync(User user)
        {
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(User user)
        {
            var oldItem = users.Where((User arg) => arg.Id == user.Id).FirstOrDefault();
            users.Remove(oldItem);
            users.Add(user);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = users.Where((User arg) => arg.Id == id).FirstOrDefault();
            users.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<User> GetItemAsync(string id)
        {
            return await Task.FromResult(users.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(users);
        }
    }
}
