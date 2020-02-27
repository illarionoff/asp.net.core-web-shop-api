using System.Collections.Generic;
using System.Threading.Tasks;
using Shop_Web_Api.Models;

namespace Shop_Web_Api.Services
{
    public interface IContactService
    {
        Task<List<Contact>> GetContactsAsync();
        Task<Contact> GetContactByUserIdAsync(string userID);
        Task<Contact> AddContactAsync(string userID, string address, string city);
        Task<bool> DeleteContactAsync(int id);
    }
}